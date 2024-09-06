namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

public class GetAllTransportOffersMadeByCompanyQuery : IQuery<List<OfferInfoDto>>
{

    public GetAllTransportOffersMadeByCompanyQuery(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; }

}