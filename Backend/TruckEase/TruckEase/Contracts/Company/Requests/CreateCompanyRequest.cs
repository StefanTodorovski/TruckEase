using Newtonsoft.Json;
using TruckEase.Enums;

public class CreateCompanyRequest
{
    public CreateCompanyRequest(
        string companyName,
        string registrationNumber,
        CompanyType companyType,
        string description)
    {
        CompanyName = companyName;
        RegistrationNumber = registrationNumber;
        CompanyType = companyType;
        Description = description;
    }

    [JsonProperty("companyName")]
    public string CompanyName { get; }

    [JsonProperty("registrationNumber")]
    public string RegistrationNumber { get; }

    [JsonProperty("companyType")]
    public CompanyType CompanyType { get; }

    [JsonProperty("description")]
    public string Description { get; }

}
