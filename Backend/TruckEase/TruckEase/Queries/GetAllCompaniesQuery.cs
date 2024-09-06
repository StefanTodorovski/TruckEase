using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

namespace TruckEase.Queries;

public class GetAllCompaniesQuery : IQuery<List<CompanyInfoDto>>
{
    public GetAllCompaniesQuery() { }
}
