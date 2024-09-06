namespace TruckEase.Vtos;

using TruckEase.ValueObjects;

public class EditCompanyVto
{
    public EditCompanyVto(
        CompanyNameValue companyName,
        CompanyRegistrationNumberValue registrationNumber,
        CompanyDescriptionValue companyDescription)
    {
        CompanyName = companyName;
        RegistrationNumber = registrationNumber;
        CompanyDescription = companyDescription;
    }

    public CompanyNameValue CompanyName { get; }

    public CompanyRegistrationNumberValue RegistrationNumber { get; }

    public CompanyDescriptionValue CompanyDescription { get; }

}
