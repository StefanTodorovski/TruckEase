namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using TruckEase.Dtos;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;

public class GetAllTransportOffersForShipperCompanyQueryHandler : IQueryHandler<GetAllTransportOffersForShipperCompanyQuery, List<OfferInfoDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllTransportOffersForShipperCompanyQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<OfferInfoDto>> Handle(GetAllTransportOffersForShipperCompanyQuery request, CancellationToken cancellationToken)
    {
        List<int> transportRequestIds = await unitOfWork.TransportRequests.AllNoTracking()
            .Where(t => t.CompanyId == request.CompanyId)
            .Select(t => t.Id)
            .ToListAsync();


        List<OfferInfoDto> offerDtos = await unitOfWork.TransportOffers.AllNoTracking()
            .Where(o => transportRequestIds.Contains(o.TransportRequestId) && o.DeletedOn == null)
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
                    offer.CompanyOffererId
                )
            )
            .ToListAsync();



        return offerDtos;

    }
}