namespace TruckEase.Contracts.TransportOffer.Responses;

public class OfferInfoResponse
{

    public int OfferId { get; set; }
    public string? AdditionalInfo { get; set; }

    public double? Price { get; set; }

    public string? OfferStatus { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public string? StartLocation { get; set; }

    public string? Destination { get; set; }

    public string? TransportType { get; set; }

    public int RequesterCompanyId { get; set; }
}
