namespace TruckEase.CommandHandlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TruckEase.Commands;
using TruckEase.Entities;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;

public class EditCompanyUserCommandHandler : ICommandHandler<EditCompanyUserCommand, Unit>
{

    private readonly IUnitOfWork unitOfWork;

    public EditCompanyUserCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditCompanyUserCommand request, CancellationToken cancellationToken)
    {
        CompanyUser user = await unitOfWork.CompanyUsers.All()
            .Where(c => c.Id == request.CompanyUserId)
            .FirstAsync();

        user.FirstName = request.EditCompanyUserVto.FirstName.Value;
        user.LastName = request.EditCompanyUserVto.LastName.Value;
        user.MobilePhone = request.EditCompanyUserVto.MobilePhone;
        user.WorkPhone = request.EditCompanyUserVto.WorkPhone;


        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}