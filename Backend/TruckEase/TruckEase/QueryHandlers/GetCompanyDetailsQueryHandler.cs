namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;

public class GetCompanyDetailsQueryHandler : IQueryHandler<GetCompanyDetailsQuery, CompanyInfoDto>
{
    private readonly IUnitOfWork unitOfWork;

    public GetCompanyDetailsQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<CompanyInfoDto> Handle(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
    {

        CompanyInfoDto companyInfo = await unitOfWork.Companies.AllNoTracking()
            .Where(c => c.Id == request.CompanyId)
            .Select(c => new CompanyInfoDto(
                c.Id,
                c.Name,
                c.RegistrationNumber,
                c.CompanyType.ToString(),
                c.Description
                ))
            .FirstAsync();



        return companyInfo;

    }
}
