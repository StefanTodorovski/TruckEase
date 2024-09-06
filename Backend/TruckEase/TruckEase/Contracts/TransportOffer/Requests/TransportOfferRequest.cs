namespace TruckEase.Contracts.TransportOffer.Requests;

using Newtonsoft.Json;

public class TransportOfferRequest
{
    [JsonProperty]
    public string? AdditionalInfo { get; private set; }

    [JsonProperty]
    public double? Price { get; private set; }

}
