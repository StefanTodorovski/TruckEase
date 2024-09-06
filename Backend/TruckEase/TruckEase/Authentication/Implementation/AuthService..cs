#nullable disable
using System.Security.Claims;
using TruckEase.Authentication.Interfaces;
using TruckEase.Exceptions;


namespace TruckEase.Authentication.Implementation;

public static class AuthService
{
    public const string UserId = "NameIdentifier";
    public const string UserFirstName = "Name";
    public const string InCompanyFK = "PostalCode";


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public static async Task<ICurrentUser> CreateCurrentUserFromClaims(HttpContext httpContext)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        ClaimsPrincipal claimsPrincipal = httpContext.User;
        if (claimsPrincipal == null || !claimsPrincipal.Claims.Any())
        {
            return CurrentUser.Empty;
        }

        string companyUserId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                         ?? throw new TruckEaseForbiddenException("User ID claim not found");

        string companyUserFirstName = claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value
                                      ?? throw new TruckEaseForbiddenException("User Name claim not found");

        string companyUserInCompanyFK = claimsPrincipal.FindFirst(ClaimTypes.PostalCode)?.Value
                                        ?? throw new TruckEaseForbiddenException("InCompanyFK claim not found");

        return CurrentUser.Create(
            int.Parse(companyUserId),
            companyUserFirstName,
            string.Empty,
            string.Empty,
            int.Parse(companyUserInCompanyFK)
          );


    }

    public static void SetCurrentUserInHttpContext(HttpContext httpContext, ICurrentUser currentUser)
    {
        var claims = new List<Claim>
        {
            new Claim(UserId, currentUser.Id.ToString()),
            new Claim(UserFirstName, currentUser.FirstName),
            new Claim(InCompanyFK, currentUser.InCompanyFK.ToString())
        };

        var identity = new ClaimsIdentity(claims, "Custom");
        var principal = new ClaimsPrincipal(identity);

        httpContext.User = principal;
    }

}
