namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;

public class FinishTransportCommand : ICommand<Unit>
{
    public FinishTransportCommand(int offerId)
    {
        OfferId = offerId;
    }

    public int OfferId { get; set; }
}