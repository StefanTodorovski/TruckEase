namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;


public class GetAllRequestsForCompanyQuery : IQuery<List<RequestDto>>
{

    public GetAllRequestsForCompanyQuery(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; }

}