#nullable disable
namespace TruckEase.Vtos;

using TruckEase.Enums;
public class EditTransportVto
{
    public string Description { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public double Price { get; set; }

    public string StartLocation { get; set; }

    public string Destination { get; set; }

    public bool IsExpress { get; set; }

    public double LoadWeight { get; set; }

    public bool IsDraft { get; set; }

    public Transport TransportType { get; set; }
}