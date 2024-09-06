namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;

public class AcceptOfferCommand : ICommand<Unit>
{
    public AcceptOfferCommand(int offerId)
    {
        OfferId = offerId;
    }

    public int OfferId { get; set; }
}