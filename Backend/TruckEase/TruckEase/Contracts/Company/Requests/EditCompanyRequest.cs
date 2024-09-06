namespace TruckEase.Contracts.Company.Requests;

using Newtonsoft.Json;

public class EditCompanyRequest
{
    public EditCompanyRequest(
        string companyName,
        string registrationNumber,
        string description)
    {
        CompanyName = companyName;
        RegistrationNumber = registrationNumber;
        Description = description;
    }

    [JsonProperty("companyName")]
    public string CompanyName { get; }

    [JsonProperty("registrationNumber")]
    public string RegistrationNumber { get; }

    [JsonProperty("description")]
    public string Description { get; }

}