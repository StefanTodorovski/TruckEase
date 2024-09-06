namespace TruckEase.CommandHandlers;

using MediatR;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Enums;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
public class CreateTransportRequestCommandHandler : ICommandHandler<CreateTransportRequestCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public CreateTransportRequestCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateTransportRequestCommand request, CancellationToken cancellationToken)
    {
        TransportRequest transportRequest = new TransportRequest
        {
            Uid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            Description = request.CreateTransportVto.Description,
            StartTime = request.CreateTransportVto.StartTime,
            ArrivalTime = request.CreateTransportVto.ArrivalTime,
            Price = request.CreateTransportVto.Price,
            StartLocation = request.CreateTransportVto.StartLocation,
            Destination = request.CreateTransportVto.Destination,
            IsExpress = request.CreateTransportVto.IsExpress,
            LoadWeight = request.CreateTransportVto.LoadWeight,
            IsDraft = request.CreateTransportVto.IsDraft,
            CompanyId = request.CompanyId,
            TransportType = request.CreateTransportVto.TransportType,
            TransportStatus = TransportStatus.Undefined
            
        };

        unitOfWork.TransportRequests.Insert(transportRequest);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}

