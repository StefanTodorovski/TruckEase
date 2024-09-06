namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Authentication.Interfaces;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Exceptions;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Utilities;

public class CreateCompanyEmployeeCommandHandler : ICommandHandler<CreateCompanyEmployeeCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;
    private readonly ICurrentUser currentUser;

    public CreateCompanyEmployeeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        this.unitOfWork = unitOfWork;
        this.currentUser = currentUser;
    }

    public async Task<Unit> Handle(CreateCompanyEmployeeCommand request, CancellationToken cancellationToken)
    {
        CompanyEmployee? existingEmployee = await unitOfWork.CompanyEmployees.All()
            .Where(c => c.Email == request.CreateCompanyEmployeeVto.Email.Value)
            .FirstOrDefaultAsync();

        CompanyUser? existingUser = await unitOfWork.CompanyUsers.All()
            .Where(c => c.Email == request.CreateCompanyEmployeeVto.Email.Value)
            .FirstOrDefaultAsync();

        if (existingEmployee != null || existingUser != null)
        {
            throw new TruckEaseAlreadyExistException(ErrorCodes.CompanyEmployeeExists);
        }

        CompanyEmployee companyEmployee = new CompanyEmployee
        {
            Uid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            FirstName = request.CreateCompanyEmployeeVto.FirstName.Value,
            LastName = request.CreateCompanyEmployeeVto.LastName.Value,
            EmployeeType = request.CreateCompanyEmployeeVto.EmployeeType,
            DeletedOn = null,
            UserId = null,
            CreatedBy = currentUser.Id,
            InCompanyFK = currentUser.InCompanyFK,
            Email = request.CreateCompanyEmployeeVto.Email.Value
        };

        unitOfWork.CompanyEmployees.Insert(companyEmployee);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}