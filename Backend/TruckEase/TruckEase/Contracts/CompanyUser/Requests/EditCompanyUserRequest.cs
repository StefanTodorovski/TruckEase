namespace TruckEase.Contracts.CompanyUser.Requests;

using Newtonsoft.Json;

public class EditCompanyUserRequest
{
    [JsonProperty]
    public string? Email { get; private set; }

    [JsonProperty]
    public string? WorkPhone { get; private set; }

    [JsonProperty]
    public string? LastName { get; private set; }

    [JsonProperty]
    public string? FirstName { get; private set; }

    [JsonProperty]
    public string? MobilePhone { get; private set; }
}
