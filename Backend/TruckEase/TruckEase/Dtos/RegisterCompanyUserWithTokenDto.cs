namespace TruckEase.Dtos;

public class RegisterCompanyUserWithTokenDto
{
    public RegisterCompanyUserWithTokenDto(string firstName, string lastName, string email, bool isUserInCompany, string token)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IsUserInCompany = isUserInCompany;
        Token = token;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsUserInCompany { get; set; }

    public string Token { get; set; }
}
