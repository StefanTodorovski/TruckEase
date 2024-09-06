#nullable disable
using Newtonsoft.Json;
using TruckEase.Enums;

namespace TruckEase.Contracts.TransportRequest.Requests;

public class CreateTransportRequest
{
    [JsonProperty]
    public string Description { get; private set; }

    [JsonProperty]
    public DateTime StartTime { get; private set; }

    [JsonProperty]
    public DateTime ArrivalTime { get; private set; }

    [JsonProperty]
    public double Price { get; private set; }

    [JsonProperty]
    public string StartLocation { get; private set; }

    [JsonProperty]
    public string Destination { get; private set; }

    [JsonProperty]
    public bool IsExpress { get; private set; }

    [JsonProperty]
    public double LoadWeight { get; private set; }

    [JsonProperty]
    public bool IsDraft { get; private set; }

    [JsonProperty]
    public Transport TransportType { get; private set; }
}