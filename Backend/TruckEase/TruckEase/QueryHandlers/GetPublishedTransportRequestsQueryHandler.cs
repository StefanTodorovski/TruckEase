namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Enums;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;

public class GetPublishedTransportRequestsQueryHandler : IQueryHandler<GetPublishedTransportRequestsQuery, List<RequestDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetPublishedTransportRequestsQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<RequestDto>> Handle(GetPublishedTransportRequestsQuery request, CancellationToken cancellationToken)
    {
        List<RequestDto> requestDtos = await unitOfWork.TransportRequests.AllNoTracking()
            .Where(t => !t.IsDraft && t.TransportStatus == TransportStatus.Undefined)
            .Select(t => new RequestDto(
                t.Id,
                t.Description,
                t.StartTime,
                t.ArrivalTime,
                t.Price,
                t.StartLocation,
                t.Destination,
                t.IsExpress,
                t.LoadWeight,
                t.IsDraft,
                t.TransportType.ToString()
                ))
            .ToListAsync();

        return requestDtos;

    }
}
