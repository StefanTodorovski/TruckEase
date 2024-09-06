namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;


public class RemoveUndefinedOfferCommandHandler : ICommandHandler<RemoveUndefinedOfferCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public RemoveUndefinedOfferCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveUndefinedOfferCommand request, CancellationToken cancellationToken)
    {
        TransportOffer offer = await unitOfWork.TransportOffers.All()
            .Where(o => o.Id == request.OfferId && o.Status == Enums.OfferStatus.Undefined)
            .FirstAsync();

        offer.DeletedOn = DateTime.UtcNow;

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}