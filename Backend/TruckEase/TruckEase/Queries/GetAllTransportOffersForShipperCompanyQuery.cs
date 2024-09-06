namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

public class GetAllTransportOffersForShipperCompanyQuery : IQuery<List<OfferInfoDto>>
{

    public GetAllTransportOffersForShipperCompanyQuery(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; }

}