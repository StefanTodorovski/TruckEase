namespace TruckEase.Dtos;

public class OfferInfoDto
{

    public OfferInfoDto(int offerId, string? additionalInfo, double? price, string offerStatus, DateTime startTime, DateTime arrivalTime, string startLocation, string destination, string transportType, int requesterCompanyId)
    {
        AdditionalInfo = additionalInfo;
        Price = price;
        OfferStatus = offerStatus;
        StartTime = startTime;
        ArrivalTime = arrivalTime;
        StartLocation = startLocation;
        Destination = destination;
        TransportType = transportType;
        OfferId = offerId;
        RequesterCompanyId = requesterCompanyId;
    }

    public int OfferId { get; set; }

    public string? AdditionalInfo { get; set; }

    public double? Price { get; set; }

    public string OfferStatus { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public string StartLocation { get; set; }

    public string Destination { get; set; }

    public string TransportType { get; set; }

    public int RequesterCompanyId { get; set; }

}