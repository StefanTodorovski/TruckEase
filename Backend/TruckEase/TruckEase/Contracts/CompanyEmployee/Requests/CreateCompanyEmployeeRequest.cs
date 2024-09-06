namespace TruckEase.Contracts.CompanyEmployee.Requests;

using Newtonsoft.Json;
using TruckEase.Enums;

public class CreateCompanyEmployeeRequest
{
    [JsonProperty]
    public string? Email { get; private set; }

    [JsonProperty]
    public string? LastName { get; private set; }

    [JsonProperty]
    public string? FirstName { get; private set; }

    [JsonProperty]
    public EmployeeType EmployeeType { get; private set; }
}
