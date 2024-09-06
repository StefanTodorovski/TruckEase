namespace TruckEase.Controllers;

using Microsoft.AspNetCore.Mvc;
using TruckEase.Commands;
using TruckEase.Contracts.TransportRequest.Mappers;
using TruckEase.Contracts.TransportRequest.Requests;
using TruckEase.Contracts.TransportRequest.Responses;
using TruckEase.Dtos;
using TruckEase.Mediator.Interfaces;
using TruckEase.Queries;
using TruckEase.Vtos;

[Route("api/transport-requests")]
[ApiController]
public class TransportRequestController : ControllerBase
{
    private readonly ITruckEaseEventsPublisher eventsPublisher;

    public TransportRequestController(ITruckEaseEventsPublisher eventsPublisher)
    {
        this.eventsPublisher = eventsPublisher;
    }

    [HttpPost("{companyId:int}/create")]
    public async Task<IActionResult> CreateTransportRequest([FromBody] CreateTransportRequest createTransportRequest, [FromRoute] int companyId)
    {
        CreateTransportVto createTransportVto = createTransportRequest.ToCreateTransportVto();

        await eventsPublisher.SendAsync(new CreateTransportRequestCommand(companyId, createTransportVto));

        return Ok();
    }

    [HttpPatch("{transportId:int}/edit")]
    public async Task<IActionResult> EditTransportRequest([FromBody] EditTransportRequest editTransportRequest, [FromRoute] int transportId)
    {
        EditTransportVto editTransportVto = editTransportRequest.ToEditTransportVto();

        await eventsPublisher.SendAsync(new EditTransportRequestCommand(transportId, editTransportVto));

        return Ok();
    }

    [HttpGet("{companyId:int}/all")]
    public async Task<ActionResult<List<RequestResponse>>> GetTransportRequestForCompany([FromRoute] int companyId)
    {
        List<RequestDto> response = await eventsPublisher.SendAsync(new GetAllRequestsForCompanyQuery(companyId));

        return Ok(response.Select(a => a.ToRequestResponse()));
    }

    [HttpGet("published")]
    public async Task<ActionResult<List<RequestResponse>>> GetPublishedTransportRequests()
    {
        List<RequestDto> response = await eventsPublisher.SendAsync(new GetPublishedTransportRequestsQuery());

        return Ok(response.Select(a => a.ToRequestResponse()));
    }

    [HttpGet("{transportId:int}/info")]
    public async Task<ActionResult<RequestResponse>> GetTransportRequestInfo([FromRoute] int transportId)
    {
        RequestDto response = await eventsPublisher.SendAsync(new GetTransportInfoQuery(transportId));

        return Ok(response);
    }

}
