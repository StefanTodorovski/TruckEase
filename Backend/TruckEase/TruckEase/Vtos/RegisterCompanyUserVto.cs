#nullable disable
using TruckEase.ValueObjects;

namespace TruckEase.Vtos;

public class RegisterCompanyUserVto
{
    public EmailValue Email { get; set; }

    public FirstNameValue FirstName { get; set; }

    public LastNameValue LastName { get; set; }

    public PasswordValue Password { get; set; }

}
