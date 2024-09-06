namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

public class GetAllActiveTransportsForTransporterCompanyQuery : IQuery<List<OfferInfoDto>>
{

    public GetAllActiveTransportsForTransporterCompanyQuery(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; }

}