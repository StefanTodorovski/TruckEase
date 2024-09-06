namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
public class RemoveContactCompanyCommandHandler : ICommandHandler<RemoveContactCompanyCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public RemoveContactCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveContactCompanyCommand request, CancellationToken cancellationToken)
    {

        int companyId = await unitOfWork.Companies.AllNoTracking()
            .Where(c => c.Id == request.CompanyId)
            .Select(c => c.Id)
            .FirstAsync();

        ContactCompany contactCompany = await unitOfWork.ContactCompanies.All()
            .Where(c => c.CompanyId == companyId)
            .FirstAsync();

        contactCompany.DeletedOn = DateTime.UtcNow;

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
