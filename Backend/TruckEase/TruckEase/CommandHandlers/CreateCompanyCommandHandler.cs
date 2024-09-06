namespace TruckEase.CommandHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Dtos;
using TruckEase.Entities;
using TruckEase.Exceptions;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Utilities;

public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, CompanyInfoDto>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<CompanyInfoDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        int? existingCompanyId = await unitOfWork.Companies.AllNoTracking()
            .Where(c => c.RegistrationNumber == request.CreateCompanyVto.RegistrationNumber)
            .Select(c => c.Id)
            .FirstOrDefaultAsync();

        if (existingCompanyId.HasValue && existingCompanyId != 0)
        {
            throw new TruckEaseAlreadyExistException(ErrorCodes.CompanyAlreadyExist);
        }

        Company company = new Company
        {
            Uid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            Name = request.CreateCompanyVto.CompanyName,
            RegistrationNumber = request.CreateCompanyVto.RegistrationNumber,
            CompanyType = request.CreateCompanyVto.CompanyType,
            Description = request.CreateCompanyVto.CompanyDescription
        };

        unitOfWork.Companies.Insert(company);

        await unitOfWork.SaveAsync();

        CompanyUser companyUser = await unitOfWork.CompanyUsers.All()
            .Where(c => c.Id == request.CompanyUserId)
            .FirstAsync();

        companyUser.InCompanyFK = company.Id;

        await unitOfWork.SaveAsync();

        return new CompanyInfoDto(company.Id, company.Name, company.RegistrationNumber, company.CompanyType.ToString(), company.Description);
    }
}