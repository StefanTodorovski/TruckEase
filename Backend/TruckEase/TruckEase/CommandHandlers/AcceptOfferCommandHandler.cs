namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Enums;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;

public class AcceptOfferCommandHandler : ICommandHandler<AcceptOfferCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public AcceptOfferCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AcceptOfferCommand request, CancellationToken cancellationToken)
    {
        TransportOffer offer = await unitOfWork.TransportOffers.All()
            .Where(o => o.Id == request.OfferId && o.Status == OfferStatus.Undefined)
            .FirstAsync();

        TransportRequest transportRequest = await unitOfWork.TransportRequests.All()
            .Where(t => t.Id == offer.TransportRequestId)
            .FirstAsync();

        transportRequest.TransportStatus = TransportStatus.Accepted;

        offer.Status = OfferStatus.Accepted;

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}