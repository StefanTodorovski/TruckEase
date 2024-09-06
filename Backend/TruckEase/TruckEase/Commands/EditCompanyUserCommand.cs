namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;

public class EditCompanyUserCommand : ICommand<Unit>
{
    public EditCompanyUserCommand(EditCompanyUserVto editCompanyUserVto, int companyUserId)
    {
        CompanyUserId = companyUserId;
        EditCompanyUserVto = editCompanyUserVto;
    }

    public EditCompanyUserVto EditCompanyUserVto { get; set; }
    public int CompanyUserId { get; set; }
}