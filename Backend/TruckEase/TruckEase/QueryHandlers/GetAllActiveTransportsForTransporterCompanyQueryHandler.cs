namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Enums;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;



public class GetAllActiveTransportsForTransporterCompanyQueryHandler : IQueryHandler<GetAllActiveTransportsForTransporterCompanyQuery, List<OfferInfoDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllActiveTransportsForTransporterCompanyQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<OfferInfoDto>> Handle(GetAllActiveTransportsForTransporterCompanyQuery request, CancellationToken cancellationToken)
    {
        List<int> activeRequestIds = await unitOfWork.TransportOffers.AllNoTracking()
            .Where(t => t.CompanyOffererId == request.CompanyId && t.Status == OfferStatus.Accepted)
            .Select(t => t.TransportRequestId)
            .ToListAsync();
  

        List<int> transportRequestIds = await unitOfWork.TransportRequests.AllNoTracking()
            .Where(t => activeRequestIds.Contains(t.Id) && t.TransportStatus == TransportStatus.Accepted)
            .Select(t => t.Id)
            .ToListAsync();


        List<OfferInfoDto> offerDtos = await unitOfWork.TransportOffers.AllNoTracking()
            .Where(o => transportRequestIds.Contains(o.TransportRequestId) && o.DeletedOn == null && o.Status == OfferStatus.Accepted)
            .Join(
                unitOfWork.TransportRequests.AllNoTracking(),
                offer => offer.TransportRequestId,
                request => request.Id,
                (offer, transportRequest) => new OfferInfoDto(
                    offer.Id,
                    offer.AdditionalInfo,
                    offer.Price,
                    offer.Status.ToString(),
                    transportRequest.StartTime,
                    transportRequest.ArrivalTime,
                    transportRequest.StartLocation,
                    transportRequest.Destination,
                    transportRequest.TransportType.ToString(),
                    transportRequest.CompanyId
                )
            )
            .ToListAsync();



        return offerDtos;

    }
}