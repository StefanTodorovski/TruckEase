#nullable disable
namespace TruckEase.Contracts.TransportRequest.Responses;

using TruckEase.Enums;
public class RequestResponse
{
    public int Id { get; set; }

    public string Description { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public double Price { get; set; }

    public string StartLocation { get; set; }

    public string Destination { get; set; }

    public bool IsExpress { get; set; }

    public double LoadWeight { get; set; }

    public bool IsDraft { get; set; }

    public string TransportType { get; set; }
}
