using System.Globalization;
using System.Security.Claims;
using TruckEase.Authentication.Interfaces;
using TruckEase.Entities;

namespace TruckEase.Authentication.Implementation;

public class UserClaimsHelper : IUserClaimsHelper
{
    public const string UserId = "user_id";
    public const string UserFirstName = "user_firstname";
    public const string UserEmail = "user_email";
    public const string InCompanyFK = "user_incompanyfk";

    public UserClaimsHelper()
    {
    }

    public List<Claim> IssueClaims(
        IEnumerable<string> requestedClaims,
        CompanyUser userData)
    {
        List<Claim> claims = new List<Claim>();

        if (requestedClaims == null)
        {
            return claims;
        }

        foreach (string claim in requestedClaims)
        {
            switch (claim)
            {
                case UserId:
                    claims.Add(new Claim(claim, userData.Id.ToString(CultureInfo.InvariantCulture)));
                    break;
                case UserFirstName:
                    claims.Add(new Claim(claim, userData.FirstName));
                    break;
                case UserEmail:
                    claims.Add(new Claim(claim, userData.Email));
                    break;
                default:
                    continue;
            }
        }

        return claims;
    }
}
