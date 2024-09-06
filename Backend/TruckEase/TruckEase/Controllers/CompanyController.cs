namespace TruckEase.Controllers;

using Microsoft.AspNetCore.Mvc;
using TruckEase.Commands;
using TruckEase.Contracts.Company.Mappers;
using TruckEase.Contracts.Company.Requests;
using TruckEase.Contracts.Company.Responses;
using TruckEase.Dtos;
using TruckEase.Mappers.Company;
using TruckEase.Mediator.Interfaces;
using TruckEase.Queries;
using TruckEase.Vtos;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ITruckEaseEventsPublisher eventsPublisher;

    public CompaniesController(ITruckEaseEventsPublisher eventsPublisher)
    {
        this.eventsPublisher = eventsPublisher;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<CompanyResponse>>> GetAllCompanies()
    {
        List<CompanyInfoDto> companies = await eventsPublisher .SendAsync(new GetAllCompaniesQuery());

        List<CompanyResponse> response = companies.Select(d => d.ToCompanyInfoResponse()).ToList();

        return Ok(response);
    }


    [HttpPost("{companyUserId:int}/register")]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest createCompanyRequest, [FromRoute] int companyUserId)
    {
        CreateCompanyVto createCompanyVto = createCompanyRequest.ToCreateCompanyVto();

        CompanyInfoDto companyInfoDto =  await eventsPublisher.SendAsync(new CreateCompanyCommand(createCompanyVto, companyUserId));

        CompanyResponse response = companyInfoDto.ToCompanyInfoResponse();

        return Ok(response);
    }

    [HttpGet("{companyId:int}/info")]
    public async Task<ActionResult<CompanyResponse>> GetCompanyDetails([FromRoute] int companyId)
    {
        CompanyInfoDto companyInfo = await eventsPublisher.SendAsync(new GetCompanyDetailsQuery(companyId));

        CompanyResponse response = companyInfo.ToCompanyInfoResponse();

        return Ok(response);
    }

    [HttpPatch("{companyId:int}/edit")]
    public async Task<IActionResult> EditCompanyInfo([FromBody] EditCompanyRequest editCompanyRequest, [FromRoute] int companyId)
    {
        EditCompanyVto editCompanyVto = editCompanyRequest.ToEditCompanyVto();

        await eventsPublisher.SendAsync(new EditCompanyCommand(editCompanyVto, companyId));

        return Ok();
    }

}
