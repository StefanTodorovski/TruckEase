namespace TruckEase.Contracts.TransportOffer.Mappers;

using TruckEase.Contracts.TransportOffer.Requests;
using TruckEase.Contracts.TransportOffer.Responses;
using TruckEase.Dtos;
using TruckEase.Vtos;

public static class TransportOfferMapper
{
    public static CreateTransportOfferVto ToCreateTransportVto(this TransportOfferRequest request)
    {
        return new CreateTransportOfferVto
        {
            AdditionalInfo = request.AdditionalInfo,
            Price = request.Price
        };
    }

    public static OfferInfoResponse ToTransportOfferInfoResponse(this OfferInfoDto requestDto)
    {
        return new OfferInfoResponse
        {
            OfferId = requestDto.OfferId,
            AdditionalInfo = requestDto.AdditionalInfo,
            Price = requestDto.Price,
            OfferStatus = requestDto.OfferStatus,
            StartTime = requestDto.StartTime,
            StartLocation = requestDto.StartLocation,
            ArrivalTime = requestDto.ArrivalTime,
            Destination = requestDto.Destination,
            TransportType = requestDto.TransportType,
            RequesterCompanyId = requestDto.RequesterCompanyId

        };
    }


}