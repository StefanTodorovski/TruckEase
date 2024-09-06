namespace TruckEase.Contracts.Company.Responses;

using TruckEase.Enums;

public class CompanyResponse
{
    public CompanyResponse(int id, string companyName, string registrationNumber, string companyType, string description)
    {
        Id = id;
        CompanyName = companyName;
        RegistrationNumber = registrationNumber;
        CompanyType = companyType;
        Description = description;
    }

    public int Id { get; set; }

    public string CompanyName { get; set; }

    public string RegistrationNumber { get; set; }

    public string CompanyType { get; set; }

    public string Description { get; set; }
}

