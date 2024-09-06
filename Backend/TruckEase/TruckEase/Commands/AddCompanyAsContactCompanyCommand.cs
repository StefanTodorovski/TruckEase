namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;

public class AddCompanyAsContactCompanyCommand : ICommand<Unit>
{
    public AddCompanyAsContactCompanyCommand(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; set; }
}