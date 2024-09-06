namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

public class GetCompanyDetailsQuery : IQuery<CompanyInfoDto>
{

    public GetCompanyDetailsQuery(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; }

}
