namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Enums;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;


public class GetAllRequestsForCompanyQueryHandler : IQueryHandler<GetAllRequestsForCompanyQuery, List<RequestDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllRequestsForCompanyQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<RequestDto>> Handle(GetAllRequestsForCompanyQuery request, CancellationToken cancellationToken)
    {
        List<RequestDto> requestDtos = await unitOfWork.TransportRequests.AllNoTracking()
            .Where(t => t.CompanyId == request.CompanyId && t.TransportStatus == TransportStatus.Undefined)
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
