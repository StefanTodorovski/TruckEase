namespace TruckEase.Commands;

using TruckEase.Dtos;
using TruckEase.Mediator.Contracts;
using TruckEase.Vtos;

public class LoginCompanyUserCommand : ICommand<RegisterCompanyUserWithTokenDto>
{
    public LoginCompanyUserCommand(LoginCompanyUserVto loginCompanyUserVto)
    {
        LoginCompanyUserVto = loginCompanyUserVto;
    }

    public LoginCompanyUserVto LoginCompanyUserVto { get; }
}