namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Authentication.Interfaces;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Exceptions;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Utilities;

public class AddCompanyAsContactCompanyCommandHandler : ICommandHandler<AddCompanyAsContactCompanyCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;
    private readonly ICurrentUser currentUser;

    public AddCompanyAsContactCompanyCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        this.unitOfWork = unitOfWork;
        this.currentUser = currentUser;
    }

    public async Task<Unit> Handle(AddCompanyAsContactCompanyCommand request, CancellationToken cancellationToken)
    {

        ContactCompany? existingContactCompany = await unitOfWork.ContactCompanies.AllNoTracking()
            .Where(c => c.CompanyId == request.CompanyId && c.DeletedOn == null)
            .FirstOrDefaultAsync();

        if (existingContactCompany != null)
        {
            throw new TruckEaseAlreadyExistException(ErrorCodes.ContactCompanyAlreadyExist);

        }

        ContactCompany contactCompany = new ContactCompany
        {
            Uid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            CreatedBy = currentUser.Id,
            DeletedOn = null,
            DeactivatedOn = null,
            CompanyId = request.CompanyId,
            ForCompanyFK = currentUser.InCompanyFK
        };

        unitOfWork.ContactCompanies.Insert(contactCompany);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
