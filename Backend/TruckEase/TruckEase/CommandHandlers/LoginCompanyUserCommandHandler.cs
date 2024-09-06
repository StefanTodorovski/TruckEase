#nullable disable
namespace TruckEase.CommandHandlers;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TruckEase.Authentication.Implementation;
using TruckEase.Authentication.Interfaces;
using TruckEase.Authentication.JWTTokenService;
using TruckEase.Commands;
using TruckEase.Dtos;
using TruckEase.Entities;
using TruckEase.Exceptions;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Mediator.Contracts;
using TruckEase.Utilities;
using TruckEase.ValueObjects;

public class LoginCompanyUserCommandHandler : ICommandHandler<LoginCompanyUserCommand, RegisterCompanyUserWithTokenDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IUserClaimsHelper userClaimsHelper;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly JwtTokenService _jwtTokenService;

    public LoginCompanyUserCommandHandler(IUnitOfWork unitOfWork, IUserClaimsHelper userClaimsHelper, IHttpContextAccessor httpContextAccessor, JwtTokenService jwtTokenService)
    {
        this.unitOfWork = unitOfWork;
        this.userClaimsHelper = userClaimsHelper;
        this.httpContextAccessor = httpContextAccessor;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<RegisterCompanyUserWithTokenDto> Handle(LoginCompanyUserCommand request, CancellationToken cancellationToken)
    {
        CompanyUser? companyUser = await unitOfWork.CompanyUsers.AllNoTracking()
            .Where(c => c.Email == request.LoginCompanyUserVto.Email)
            .FirstOrDefaultAsync();

        if (companyUser == null)
        {
            throw new TruckEaseForbiddenException(ErrorCodes.EmailNotExist);
        }

        PasswordValue hashedPassword = PasswordValue.CreateFromGuess(request.LoginCompanyUserVto.Password, new Guid(companyUser.PasswordSalt).ToByteArray());

        PasswordValue userPassword = PasswordValue.CreateFromHash(companyUser.PasswordHash, companyUser.PasswordSalt);

        if (hashedPassword != userPassword)
        {
            throw new TruckEaseForbiddenException(ErrorCodes.PasswordInvalid);
        }

        bool isUserInCompany = companyUser.InCompanyFK.HasValue ? true : false;

        List<string> requestedClaimTypes = new List<string>
        {
            "UserId",
            "UserFirstName",
            "UserEmail",
            "InCompanyFK"
        };

        userClaimsHelper.IssueClaims(requestedClaimTypes, companyUser);

        CurrentUser currentUser = CurrentUser.Create(
            companyUser.Id,
            companyUser.FirstName,
            companyUser.LastName,
            companyUser.Email,
        companyUser.InCompanyFK ?? 0
        );

        int InCompanyFK = companyUser.InCompanyFK ?? 0;

        string token = _jwtTokenService.GenerateToken(companyUser.Id.ToString(), companyUser.FirstName, InCompanyFK.ToString());


        AuthService.SetCurrentUserInHttpContext(httpContextAccessor.HttpContext, currentUser);

        return new RegisterCompanyUserWithTokenDto(companyUser.FirstName, companyUser.LastName, companyUser.Email, isUserInCompany, token);

    }
}