namespace TruckEase.Vtos;

using TruckEase.Enums;
using TruckEase.ValueObjects;

public class CreateCompanyVto
{
    public CreateCompanyVto(
        CompanyNameValue companyName,
        CompanyRegistrationNumberValue registrationNumber,
        CompanyType companyType,
        CompanyDescriptionValue companyDescription)
    {
        CompanyName = companyName;
        RegistrationNumber = registrationNumber;
        CompanyType = companyType;
        CompanyDescription = companyDescription;
    }

    public CompanyNameValue CompanyName { get; }

    public CompanyRegistrationNumberValue RegistrationNumber { get; }

    public CompanyType CompanyType { get; }

    public CompanyDescriptionValue CompanyDescription { get; }

}
