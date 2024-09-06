namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
public class DeclineOfferCommand : ICommand<Unit>
{
    public DeclineOfferCommand(int offerId)
    {
        OfferId = offerId;
    }

    public int OfferId { get; set; }
}