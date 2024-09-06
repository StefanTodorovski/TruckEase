namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;

public class CreateTransportRequestCommand : ICommand<Unit>
{
    public CreateTransportRequestCommand(int companyId, CreateTransportVto createTransportVto)
    {
        CompanyId = companyId;
        CreateTransportVto = createTransportVto;
    }

    public int CompanyId {  get; set; }

    public CreateTransportVto CreateTransportVto { get; }
}