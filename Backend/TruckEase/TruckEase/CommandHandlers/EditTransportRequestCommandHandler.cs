namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
public class EditTransportRequestCommandHandler : ICommandHandler<EditTransportRequestCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public EditTransportRequestCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditTransportRequestCommand request, CancellationToken cancellationToken)
    {
        TransportRequest transportRequest = await unitOfWork.TransportRequests.All()
            .Where(t => t.Id == request.TransportRequestId)
            .FirstAsync();

        transportRequest.Description = request.EditTransportVto.Description;
        transportRequest.StartTime = request.EditTransportVto.StartTime;
        transportRequest.ArrivalTime = request.EditTransportVto.ArrivalTime;
        transportRequest.Price = request.EditTransportVto.Price;
        transportRequest.StartLocation = request.EditTransportVto.StartLocation;
        transportRequest.Destination = request.EditTransportVto.Destination;
        transportRequest.IsExpress = request.EditTransportVto.IsExpress;
        transportRequest.LoadWeight = request.EditTransportVto.LoadWeight;
        transportRequest.IsDraft = request.EditTransportVto.IsDraft;
        transportRequest.TransportType = request.EditTransportVto.TransportType;

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}