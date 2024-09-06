namespace TruckEase.CommandHandlers;

using MediatR;
using TruckEase.Authentication.Interfaces;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Enums;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;


public class CreateTransportOfferCommandHandler : ICommandHandler<CreateTransportOfferCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;
    private readonly ICurrentUser currentUser;

    public CreateTransportOfferCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        this.unitOfWork = unitOfWork;
        this.currentUser = currentUser;
    }

    public async Task<Unit> Handle(CreateTransportOfferCommand request, CancellationToken cancellationToken)
    {

        TransportOffer transportOffer = new TransportOffer
        {
            Uid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            DeletedOn = null,
            AdditionalInfo = request.CreateTransportOfferVto.AdditionalInfo,
            CompanyOffererId = currentUser.InCompanyFK,
            TransportRequestId = request.TransportRequestId,
            Status = OfferStatus.Undefined,
            Price = request.CreateTransportOfferVto.Price ?? null,
        };

        unitOfWork.TransportOffers.Insert(transportOffer);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}