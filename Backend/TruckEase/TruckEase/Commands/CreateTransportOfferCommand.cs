namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;
public class CreateTransportOfferCommand : ICommand<Unit>
{
    public CreateTransportOfferCommand(CreateTransportOfferVto createTransportOfferVto, int transportRequestId)
    {
        TransportRequestId = transportRequestId;
        CreateTransportOfferVto = createTransportOfferVto;
    }

    public CreateTransportOfferVto CreateTransportOfferVto { get; set; }
    public int TransportRequestId { get; set; }
}