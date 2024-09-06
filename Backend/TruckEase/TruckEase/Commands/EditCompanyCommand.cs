namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;

public class EditCompanyCommand : ICommand<Unit>
{
    public EditCompanyCommand(EditCompanyVto editCompanyVto, int companyId)
    {
        CompanyId = companyId;
        EditCompanyVto = editCompanyVto;
    }

    public EditCompanyVto EditCompanyVto { get; set; }
    public int CompanyId { get; set; }
}