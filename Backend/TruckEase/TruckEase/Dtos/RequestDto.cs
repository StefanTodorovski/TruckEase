namespace TruckEase.Dtos;

using TruckEase.Enums;

public class RequestDto
{
    public RequestDto(
        int id,
        string description,
        DateTime startTime,
        DateTime arrivalTime,
        double price,
        string startLocation,
        string destination,
        bool isExpress,
        double loadWeight,
        bool isDraft,
        string transportType)
    {
        Id = id;
        Description = description;
        StartTime = startTime;
        ArrivalTime = arrivalTime;
        Price = price;
        StartLocation = startLocation;
        Destination = destination;
        IsExpress = isExpress;
        LoadWeight = loadWeight;
        IsDraft = isDraft;
        TransportType = transportType;
    }

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
