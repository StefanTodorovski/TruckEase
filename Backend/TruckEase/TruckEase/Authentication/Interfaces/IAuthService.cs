using System.Security.Claims;

namespace TruckEase.Authentication.Interfaces;

public interface IAuthService
{
    ICurrentUser CreateCurrentUserFromClaims(ClaimsPrincipal claimsPrincipal);

}
