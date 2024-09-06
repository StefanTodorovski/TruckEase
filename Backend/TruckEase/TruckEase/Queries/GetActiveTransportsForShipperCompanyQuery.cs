namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

public class GetActiveTransportsForShipperCompanyQuery : IQuery<List<OfferInfoDto>>
{

    public GetActiveTransportsForShipperCompanyQuery(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; }

}