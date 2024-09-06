namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;

public class EditTransportRequestCommand : ICommand<Unit>
{
    public EditTransportRequestCommand(int transportRequestId, EditTransportVto editTransportVto)
    {
        TransportRequestId = transportRequestId;
        EditTransportVto = editTransportVto;
    }

    public int TransportRequestId { get; set; }

    public EditTransportVto EditTransportVto { get; }
}