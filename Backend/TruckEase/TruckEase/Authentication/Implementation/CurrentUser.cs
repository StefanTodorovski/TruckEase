using TruckEase.Authentication.Interfaces;

namespace TruckEase.Authentication.Implementation;

public class CurrentUser : ICurrentUser
{
    private CurrentUser(int id, string firstName, string lastName, string email, int inCompanyFK)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        InCompanyFK = inCompanyFK;
    }

    public static CurrentUser Empty => Create(id: default, firstName: string.Empty, lastName: string.Empty, email: string.Empty, inCompanyFK: default);

    public int Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public int InCompanyFK { get; private set; }

    public static CurrentUser Create(int id, string firstName, string lastName, string email, int inCompanyFK)
    {
        return new CurrentUser(id, firstName, lastName, email, inCompanyFK);
    }

}
