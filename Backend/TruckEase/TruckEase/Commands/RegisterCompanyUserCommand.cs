using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;

namespace TruckEase.Commands;

public class RegisterCompanyUserCommand : ICommand<RegisterCompanyUserDto>
{
    public RegisterCompanyUserCommand(RegisterCompanyUserVto registerCompanyUserVto)
    {
        RegisterCompanyUserVto = registerCompanyUserVto;
    }

    public RegisterCompanyUserVto RegisterCompanyUserVto { get; }
}