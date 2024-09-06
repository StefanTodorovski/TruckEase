namespace TruckEase.Authentication.Interfaces;

public interface ICurrentUser
{
    int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public int InCompanyFK { get; }

}
