#nullable disable
namespace TruckEase.Contracts.CompanyUser.Responses;

public class RegisterCompanyUserWithTokenResponse
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsUserInCompany { get; set; }

    public string Token { get; set; }
}