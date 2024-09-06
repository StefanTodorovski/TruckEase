namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
public class RemoveUndefinedOfferCommand : ICommand<Unit>
{
    public RemoveUndefinedOfferCommand(int offerId)
    {
        OfferId = offerId;
    }

    public int OfferId { get; set; }
}