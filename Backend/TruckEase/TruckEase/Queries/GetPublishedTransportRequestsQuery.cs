namespace TruckEase.Queries;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;

public class GetPublishedTransportRequestsQuery : IQuery<List<RequestDto>>
{
    public GetPublishedTransportRequestsQuery() { }
}