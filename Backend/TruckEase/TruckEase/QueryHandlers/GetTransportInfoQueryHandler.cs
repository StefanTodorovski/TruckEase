namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;
public class GetTransportInfoQueryHandler : IQueryHandler<GetTransportInfoQuery, RequestDto>
{
    private readonly IUnitOfWork unitOfWork;

    public GetTransportInfoQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<RequestDto> Handle(GetTransportInfoQuery request, CancellationToken cancellationToken)
    {
        RequestDto requestDto = await unitOfWork.TransportRequests.AllNoTracking()
            .Where(t => t.Id == request.TransportId)
            .Select(t => new RequestDto(
                t.Id,
                t.Description,
                t.StartTime,
                t.ArrivalTime,
                t.Price,
                t.StartLocation,
                t.Description,
                t.IsExpress,
                t.LoadWeight,
                t.IsDraft,
                t.TransportType.ToString()
                ))
            .FirstAsync();

        return requestDto;

    }
}