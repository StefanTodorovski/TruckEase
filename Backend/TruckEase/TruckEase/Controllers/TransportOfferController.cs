namespace TruckEase.Controllers;

using Microsoft.AspNetCore.Mvc;
using TruckEase.Commands;
using TruckEase.Contracts.TransportOffer.Mappers;
using TruckEase.Contracts.TransportOffer.Requests;
using TruckEase.Contracts.TransportOffer.Responses;
using TruckEase.Dtos;
using TruckEase.Mediator.Interfaces;
using TruckEase.Queries;
using TruckEase.Vtos;

[Route("api/transport-offer")]
[ApiController]
public class TransportOfferController : ControllerBase
{
    private readonly ITruckEaseEventsPublisher eventsPublisher;

    public TransportOfferController(ITruckEaseEventsPublisher eventsPublisher)
    {
        this.eventsPublisher = eventsPublisher;
    }

    [HttpPost("{transportRequestId:int}/create")]
    public async Task<IActionResult> CreateTransportRequest([FromBody] TransportOfferRequest transportOfferRequest, [FromRoute] int transportRequestId)
    {
        CreateTransportOfferVto createTransportOfferVto = transportOfferRequest.ToCreateTransportVto();

        await eventsPublisher.SendAsync(new CreateTransportOfferCommand(createTransportOfferVto, transportRequestId));

        return Ok();
    }

    [HttpGet("{companyId:int}/all")]
    public async Task<ActionResult<List<OfferInfoResponse>>> GetAllOffersForCompany([FromRoute] int companyId)
    {
        List<OfferInfoDto> companies = await eventsPublisher.SendAsync(new GetAllTransportOffersMadeByCompanyQuery(companyId));

        List<OfferInfoResponse> response = companies.Select(d => d.ToTransportOfferInfoResponse()).ToList();

        return Ok(response);
    }

    [HttpGet("{companyId:int}/offers")]
    public async Task<ActionResult<List<OfferInfoResponse>>> GetAllOffersForShipperCompany([FromRoute] int companyId)
    {
        List<OfferInfoDto> companies = await eventsPublisher.SendAsync(new GetAllTransportOffersForShipperCompanyQuery(companyId));

        List<OfferInfoResponse> response = companies.Select(d => d.ToTransportOfferInfoResponse()).ToList();

        return Ok(response);
    }

    [HttpGet("{companyId:int}/active-transports")]
    public async Task<ActionResult<List<OfferInfoResponse>>> GetAllActiveTransportsForShipperCompany([FromRoute] int companyId)
    {
        List<OfferInfoDto> companies = await eventsPublisher.SendAsync(new GetActiveTransportsForShipperCompanyQuery(companyId));

        List<OfferInfoResponse> response = companies.Select(d => d.ToTransportOfferInfoResponse()).ToList();

        return Ok(response);
    }

    [HttpGet("{companyId:int}/active-transports-transporter")]
    public async Task<ActionResult<List<OfferInfoResponse>>> GetAllActiveTransportsForTransporterCompany([FromRoute] int companyId)
    {
        List<OfferInfoDto> companies = await eventsPublisher.SendAsync(new GetAllActiveTransportsForTransporterCompanyQuery(companyId));

        List<OfferInfoResponse> response = companies.Select(d => d.ToTransportOfferInfoResponse()).ToList();

        return Ok(response);
    }

    [HttpPost("{offerId:int}/remove")]
    public async Task<IActionResult> RemoveUndefinedOffer([FromRoute] int offerId)
    {

        await eventsPublisher.SendAsync(new RemoveUndefinedOfferCommand(offerId));

        return Ok();
    }

    [HttpPost("{offerId:int}/accept")]
    public async Task<IActionResult> AcceptOffer([FromRoute] int offerId)
    {

        await eventsPublisher.SendAsync(new AcceptOfferCommand(offerId));

        return Ok();
    }

    [HttpPost("{offerId:int}/decline")]
    public async Task<IActionResult> DeclineOffer([FromRoute] int offerId)
    {

        await eventsPublisher.SendAsync(new DeclineOfferCommand(offerId));

        return Ok();
    }

    [HttpPost("{offerId:int}/finished")]
    public async Task<IActionResult> FinishTransport([FromRoute] int offerId)
    {

        await eventsPublisher.SendAsync(new FinishTransportCommand(offerId));

        return Ok();
    }


}
