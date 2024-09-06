#nullable disable
namespace TruckEase.Contracts.CompanyUser.Requests;

using Newtonsoft.Json;

public class LoginRequest
{
    [JsonProperty]
    public string Email { get; private set; }

    [JsonProperty]
    public string Password { get; private set; }

}