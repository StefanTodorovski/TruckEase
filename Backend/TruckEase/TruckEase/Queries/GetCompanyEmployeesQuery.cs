namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;


public class GetCompanyEmployeesQuery : IQuery<List<EmployeeInfoDto>>
{

    public GetCompanyEmployeesQuery(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; }

}