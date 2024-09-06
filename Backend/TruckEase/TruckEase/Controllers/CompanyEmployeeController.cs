namespace TruckEase.Controllers;

using Microsoft.AspNetCore.Mvc;
using TruckEase.Commands;
using TruckEase.Contracts.CompanyEmployee.Mappers;
using TruckEase.Contracts.CompanyEmployee.Requests;
using TruckEase.Contracts.CompanyEmployee.Responses;
using TruckEase.Dtos;
using TruckEase.Mediator.Interfaces;
using TruckEase.Queries;
using TruckEase.Vtos;




[Route("api/company-employee")]
[ApiController]
public class CompanyEmployeeController : ControllerBase
{
    private readonly ITruckEaseEventsPublisher eventsPublisher;

    public CompanyEmployeeController(ITruckEaseEventsPublisher eventsPublisher)
    {
        this.eventsPublisher = eventsPublisher;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterCompanyUser([FromBody] CreateCompanyEmployeeRequest request)
    {
        CreateCompanyEmployeeVto createCompanyEmployeeVto = request.ToCreateCompanyEmployeeVto();

        await eventsPublisher.SendAsync(new CreateCompanyEmployeeCommand(createCompanyEmployeeVto));

        return Ok();
    }

    [HttpGet("{companyId:int}/all")]
    public async Task<ActionResult<List<EmployeeInfoResponse>>> GetAllContactCompanies([FromRoute] int companyId)
    {
        List<EmployeeInfoDto> companies = await eventsPublisher.SendAsync(new GetCompanyEmployeesQuery(companyId));

        List<EmployeeInfoResponse> response = companies.Select(d => d.ToEmployeeInfoResponse()).ToList();

        return Ok(response);
    }


}