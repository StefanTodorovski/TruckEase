namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;

public class GetContactCompaniesForCompanyQueryHandler : IQueryHandler<GetContactCompaniesForCompanyQuery, List<CompanyInfoDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetContactCompaniesForCompanyQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<CompanyInfoDto>> Handle(GetContactCompaniesForCompanyQuery request, CancellationToken cancellationToken)
    {

        List<int> contactCompaniesIds = await unitOfWork.ContactCompanies.AllNoTracking()
            .Where(c => c.ForCompanyFK == request.CompanyId && c.DeletedOn == null)
            .Select(c => c.CompanyId)
            .ToListAsync();

        List<CompanyInfoDto> companies = await unitOfWork.Companies.AllNoTracking()
            .Where(c => contactCompaniesIds.Contains(c.Id))
            .Select(c => new CompanyInfoDto(
                c.Id,
                c.Name,
                c.RegistrationNumber,
                c.CompanyType.ToString(),
                c.Description
                ))
            .ToListAsync();

        return companies;

    }
}