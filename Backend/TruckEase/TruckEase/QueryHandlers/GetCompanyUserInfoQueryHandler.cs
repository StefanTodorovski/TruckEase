using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;

namespace TruckEase.QueryHandlers;

public class GetCompanyUserInfoQueryHandler : IQueryHandler<GetCompanyUserInfoQuery, CompanyUserInfoDto>
{
    private readonly IUnitOfWork unitOfWork;

    public GetCompanyUserInfoQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<CompanyUserInfoDto> Handle(GetCompanyUserInfoQuery request, CancellationToken cancellationToken)
    {

        CompanyUserInfoDto companyUserInfo = await unitOfWork.CompanyUsers.AllNoTracking()
            .Where(c => c.Id == request.CompanyUserId)
            .Select(c => new CompanyUserInfoDto(
                c.FirstName,
                c.LastName,
                c.Email,
                c.JobTitle,
                c.WorkPhone,
                c.MobilePhone
                ))
            .FirstAsync();



        return companyUserInfo;

    }
}
