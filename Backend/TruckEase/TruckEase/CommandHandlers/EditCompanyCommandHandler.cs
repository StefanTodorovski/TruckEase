namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Exceptions;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Utilities;

public class EditCompanyCommandHandler : ICommandHandler<EditCompanyCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public EditCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
    {
        Company company = await unitOfWork.Companies.All()
            .Where(c =>c.Id == request.CompanyId)
            .FirstAsync();

        string? existingRegistrationNumber = await unitOfWork.Companies.All()
            .Where(c => c.Id != request.CompanyId && c.RegistrationNumber == request.EditCompanyVto.RegistrationNumber.Value)
            .Select(c => c.RegistrationNumber)
            .FirstOrDefaultAsync();

        if (existingRegistrationNumber != null)
        {
            throw new TruckEaseAlreadyExistException(ErrorCodes.CompanyAlreadyExist);
        }

        company.Name = request.EditCompanyVto.CompanyName.Value;
        company.RegistrationNumber = request.EditCompanyVto.RegistrationNumber.Value;
        company.Description = request.EditCompanyVto.CompanyDescription.Value;

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
