namespace TruckEase.Dtos;
public class RegisterCompanyUserDto
{
    public RegisterCompanyUserDto(string firstName, string lastName, string email, bool isUserInCompany)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IsUserInCompany = isUserInCompany;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsUserInCompany { get; set; }
}

