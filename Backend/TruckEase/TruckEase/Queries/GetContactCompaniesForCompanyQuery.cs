namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;
public class GetContactCompaniesForCompanyQuery : IQuery<List<CompanyInfoDto>>
{

    public GetContactCompaniesForCompanyQuery(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; }

}