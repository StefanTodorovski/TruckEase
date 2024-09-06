namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

public class GetTransportInfoQuery : IQuery<RequestDto>
{

    public GetTransportInfoQuery(int transportId)
    {
        TransportId = transportId;
    }

    public int TransportId { get; }

}