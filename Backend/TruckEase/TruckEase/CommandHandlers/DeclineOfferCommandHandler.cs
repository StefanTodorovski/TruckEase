namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Enums;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;


public class DeclineOfferCommandHandler : ICommandHandler<DeclineOfferCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public DeclineOfferCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeclineOfferCommand request, CancellationToken cancellationToken)
    {
        TransportOffer offer = await unitOfWork.TransportOffers.All()
            .Where(o => o.Id == request.OfferId && o.Status == OfferStatus.Undefined)
            .FirstAsync();

        offer.Status = OfferStatus.Declined;

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}