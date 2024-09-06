namespace TruckEase.Commands;

using MediatR;
using TruckEase.Mediator.Contracts;
public class RemoveContactCompanyCommand : ICommand<Unit>
{
    public RemoveContactCompanyCommand(int companyId)
    {
        CompanyId = companyId;
    }

    public int CompanyId { get; set; }
}