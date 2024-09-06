namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Enums;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;

public class FinishTransportCommandHandler : ICommandHandler<FinishTransportCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public FinishTransportCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(FinishTransportCommand request, CancellationToken cancellationToken)
    {
        TransportOffer offer = await unitOfWork.TransportOffers.All()
            .Where(o => o.Id == request.OfferId && o.Status == OfferStatus.Accepted)
            .FirstAsync();

        TransportRequest transportRequest = await unitOfWork.TransportRequests.All()
            .Where(t => t.Id == offer.TransportRequestId)
            .FirstAsync();

        transportRequest.TransportStatus = TransportStatus.Finished;

        offer.Status = OfferStatus.Finished;

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}