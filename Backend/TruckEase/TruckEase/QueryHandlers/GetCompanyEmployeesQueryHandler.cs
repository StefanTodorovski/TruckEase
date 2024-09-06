namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;


public class GetCompanyEmployeesQueryHandler : IQueryHandler<GetCompanyEmployeesQuery, List<EmployeeInfoDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetCompanyEmployeesQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<EmployeeInfoDto>> Handle(GetCompanyEmployeesQuery request, CancellationToken cancellationToken)
    {

        List<EmployeeInfoDto> companyEmployees = await unitOfWork.CompanyEmployees.AllNoTracking()
            .Where(c => c.InCompanyFK == request.CompanyId && c.DeletedOn == null)
            .Select(c => new EmployeeInfoDto(
                c.FirstName,
                c.LastName,
                c.Email,
                c.EmployeeType.ToString()
                ))
            .ToListAsync();


        return companyEmployees;

    }
}