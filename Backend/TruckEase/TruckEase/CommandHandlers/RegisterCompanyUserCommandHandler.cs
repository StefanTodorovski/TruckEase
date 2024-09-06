namespace TruckEase.CommandHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Dtos;
using TruckEase.Entities;
using TruckEase.Exceptions;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Utilities;


public class RegisterCompanyUserCommandHandler : ICommandHandler<RegisterCompanyUserCommand, RegisterCompanyUserDto>
{
    private readonly IUnitOfWork unitOfWork;

    public RegisterCompanyUserCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<RegisterCompanyUserDto> Handle(RegisterCompanyUserCommand request, CancellationToken cancellationToken)
    {
        bool isUserInCompany = false;

        CompanyUser? existingCompanyUser = await unitOfWork.CompanyUsers.AllNoTracking()
            .Where(c => c.Email == request.RegisterCompanyUserVto.Email)
            .FirstOrDefaultAsync();

        if(existingCompanyUser != null)
        {
            throw new TruckEaseConflictException(ErrorCodes.EmailAlreadyExist);
        }

        CompanyEmployee? existingEmployeeCompany = await unitOfWork.CompanyEmployees.AllNoTracking()
            .Where(c => c.Email == request.RegisterCompanyUserVto.Email)
            .FirstOrDefaultAsync();

        CompanyUser companyUser = new CompanyUser
        {
            Uid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            FirstName = request.RegisterCompanyUserVto.FirstName.Value,
            LastName = request.RegisterCompanyUserVto.LastName.Value,
            PasswordHash = request.RegisterCompanyUserVto.Password.Hash,
            PasswordSalt = request.RegisterCompanyUserVto.Password.Salt,
            DeletedOn = null,
            IsVerified = true,
            Email = request.RegisterCompanyUserVto.Email
        };

        if (existingEmployeeCompany != null)
        {
            isUserInCompany = true;
            companyUser.InCompanyFK = existingEmployeeCompany.InCompanyFK;
            
        }

        unitOfWork.CompanyUsers.Insert(companyUser);

        await unitOfWork.SaveAsync();

        return new RegisterCompanyUserDto(companyUser.FirstName, companyUser.LastName, companyUser.Email, isUserInCompany);

    }
}