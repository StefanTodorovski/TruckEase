namespace TruckEase.QueryHandlers;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using TruckEase.Dtos;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Queries;



public class GetAllTransportOffersMadeByCompanyQueryHandler : IQueryHandler<GetAllTransportOffersMadeByCompanyQuery, List<OfferInfoDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllTransportOffersMadeByCompanyQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<OfferInfoDto>> Handle(GetAllTransportOffersMadeByCompanyQuery request, CancellationToken cancellationToken)
    {

        List<OfferInfoDto> offerDtos = await unitOfWork.TransportOffers.AllNoTracking()
            .Where(o => o.CompanyOffererId == request.CompanyId && o.DeletedOn == null)
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