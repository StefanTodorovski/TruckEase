namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;

public class GetAllCompaniesQueryHandler : IQueryHandler<GetAllCompaniesQuery, List<CompanyInfoDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllCompaniesQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<CompanyInfoDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {

        List<CompanyInfoDto> companies = await unitOfWork.Companies.AllNoTracking()
            .Select(c => new CompanyInfoDto(
                c.Id,
                c.Name,
                c.RegistrationNumber,
                c.CompanyType.ToString(),
                c.Description
                ))
            .ToListAsync();

        return companies;

    }
}