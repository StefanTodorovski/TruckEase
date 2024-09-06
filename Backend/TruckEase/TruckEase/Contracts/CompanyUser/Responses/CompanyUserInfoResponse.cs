namespace TruckEase.Contracts.CompanyUser.Responses;

public class CompanyUserInfoResponse
{
    public CompanyUserInfoResponse(string firstName, string lastName, string email, string? jobTitle, string? workPhone, string? mobilePhone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        JobTitle = jobTitle;
        WorkPhone = workPhone;
        MobilePhone = mobilePhone;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string? JobTitle { get; set; }

    public string? WorkPhone { get; set; }

    public string? MobilePhone { get; set; }
}
