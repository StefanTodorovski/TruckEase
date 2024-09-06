namespace TruckEase.Commands;

using TruckEase.Dtos;
using TruckEase.Entities;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;

public class CreateCompanyCommand : ICommand<CompanyInfoDto>
{
    public CreateCompanyCommand(CreateCompanyVto createCompanyVto, int companyUserId)
    {
        CreateCompanyVto = createCompanyVto;
        CompanyUserId = companyUserId;
    }

    public CreateCompanyVto CreateCompanyVto { get; }

    public int CompanyUserId { get; }
}