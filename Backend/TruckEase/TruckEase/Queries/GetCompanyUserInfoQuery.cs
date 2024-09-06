namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

public class GetCompanyUserInfoQuery : IQuery<CompanyUserInfoDto>
{

    public GetCompanyUserInfoQuery(int companyUserId)
    {
        CompanyUserId = companyUserId;
    }

    public int CompanyUserId { get; }

}

