namespace TruckEase.Contracts.TransportRequest.Mappers;

using TruckEase.Contracts.TransportRequest.Requests;
using TruckEase.Contracts.TransportRequest.Responses;
using TruckEase.Dtos;
using TruckEase.Vtos;


public static class TransportRequestMapper
{
    public static CreateTransportVto ToCreateTransportVto(this CreateTransportRequest request)
    {
        return new CreateTransportVto
        {
            Description = request.Description,
            StartTime = request.StartTime,
            ArrivalTime = request.ArrivalTime,
            Price = request.Price,
            StartLocation = request.StartLocation,
            Destination = request.Destination,
            IsExpress = request.IsExpress,
            LoadWeight = request.LoadWeight,
            IsDraft = request.IsDraft,
            TransportType = request.TransportType,

        };
    }

    public static EditTransportVto ToEditTransportVto(this EditTransportRequest request)
    {
        return new EditTransportVto
        {
            Description = request.Description,
            StartTime = request.StartTime,
            ArrivalTime = request.ArrivalTime,
            Price = request.Price,
            StartLocation = request.StartLocation,
            Destination = request.Destination,
            IsExpress = request.IsExpress,
            LoadWeight = request.LoadWeight,
            IsDraft = request.IsDraft,
            TransportType = request.TransportType,

        };
    }

    public static RequestResponse ToRequestResponse(this RequestDto requestDto)
    {
        return new RequestResponse
        {
            Id = requestDto.Id,
            Description = requestDto.Description,
            StartTime = requestDto.StartTime,
            ArrivalTime = requestDto.ArrivalTime,
            Price = requestDto.Price,
            StartLocation = requestDto.StartLocation,
            Destination = requestDto.Destination,
            IsExpress = requestDto.IsExpress,
            LoadWeight = requestDto.LoadWeight,
            IsDraft = requestDto.IsDraft,
            TransportType = requestDto.TransportType,

        };
    }

}
