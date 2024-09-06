namespace TruckEase.Controllers;

using Microsoft.AspNetCore.Mvc;
using TruckEase.Commands;
using TruckEase.Contracts.Company.Mappers;
using TruckEase.Contracts.Company.Responses;
using TruckEase.Dtos;
using TruckEase.Mediator.Interfaces;
using TruckEase.Queries;

[Route("api/contact-company")]
[ApiController]
public class ContactCompanyController : ControllerBase
{
    private readonly ITruckEaseEventsPublisher eventsPublisher;

    public ContactCompanyController(ITruckEaseEventsPublisher eventsPublisher)
    {
        this.eventsPublisher = eventsPublisher;
    }


    [HttpPost("{companyId:int}/add-to-supply-chain")]
    public async Task<IActionResult> CreateCompany([FromRoute] int companyId)
    {

        await eventsPublisher.SendAsync(new AddCompanyAsContactCompanyCommand(companyId));

        return Ok();
    }

    [HttpGet("{companyId:int}/all")]
    public async Task<ActionResult<List<CompanyResponse>>> GetAllContactCompanies([FromRoute] int companyId)
    {
        List<CompanyInfoDto> companies = await eventsPublisher.SendAsync(new GetContactCompaniesForCompanyQuery(companyId));

        List<CompanyResponse> response = companies.Select(d => d.ToCompanyInfoResponse()).ToList();

        return Ok(response);
    }

    [HttpPost("{companyId:int}/remove")]
    public async Task<IActionResult> RemoveContactCompany([FromRoute] int companyId)
    {

        await eventsPublisher.SendAsync(new RemoveContactCompanyCommand(companyId));

        return Ok();
    }

}