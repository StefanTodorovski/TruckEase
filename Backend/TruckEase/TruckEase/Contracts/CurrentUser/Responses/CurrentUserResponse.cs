namespace TruckEase.Contracts.CurrentUser.Responses;

public class CurrentUserResponse
{
    public CurrentUserResponse(
        int id,
        string firstName,
        string lastName,
        string email,
        int inCompanyFK)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        InCompanyFK = inCompanyFK;
    }

    public int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public int InCompanyFK { get; }

}
