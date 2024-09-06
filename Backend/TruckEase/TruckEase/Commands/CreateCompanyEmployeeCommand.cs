namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;

public class CreateCompanyEmployeeCommand : ICommand<Unit>
{
    public CreateCompanyEmployeeCommand(CreateCompanyEmployeeVto createCompanyEmployeeVto)
    {
        CreateCompanyEmployeeVto = createCompanyEmployeeVto;
    }

    public CreateCompanyEmployeeVto CreateCompanyEmployeeVto { get; set; }
}