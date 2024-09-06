using System.Security.Claims;
using TruckEase.Entities;

namespace TruckEase.Authentication.Interfaces;

public interface IUserClaimsHelper
{
    List<Claim> IssueClaims(IEnumerable<string> requestedClaims, CompanyUser userData);
}