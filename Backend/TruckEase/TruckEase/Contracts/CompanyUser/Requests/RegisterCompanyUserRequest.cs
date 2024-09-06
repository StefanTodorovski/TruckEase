#nullable disable
using Newtonsoft.Json;

namespace TruckEase.Contracts.CompanyUser.Requests;

public class RegisterCompanyUserRequest
{
    [JsonProperty]
    public string Email { get; private set; }

    [JsonProperty]
    public string Password { get; private set; }

    [JsonProperty]
    public string LastName { get; private set; }

    [JsonProperty]
    public string FirstName { get; private set; }
}
