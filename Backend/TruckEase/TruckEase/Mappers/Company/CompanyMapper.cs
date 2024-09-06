using TruckEase.Contracts.Company.Requests;
using TruckEase.ValueObjects;
using TruckEase.Vtos;

namespace TruckEase.Mappers.Company;

public static class CompanyMapper
{
    public static CreateCompanyVto ToCreateCompanyVto(this CreateCompanyRequest createCompanyRequest)
    {
        return new CreateCompanyVto(
            CompanyNameValue.Create(createCompanyRequest.CompanyName),
            CompanyRegistrationNumberValue.Create(createCompanyRequest.RegistrationNumber),
            createCompanyRequest.CompanyType,
            CompanyDescriptionValue.Create(createCompanyRequest.Description));
    }

    public static EditCompanyVto ToEditCompanyVto(this EditCompanyRequest editCompanyRequest)
    {
        return new EditCompanyVto(
            CompanyNameValue.Create(editCompanyRequest.CompanyName),
            CompanyRegistrationNumberValue.Create(editCompanyRequest.RegistrationNumber),
            CompanyDescriptionValue.Create(editCompanyRequest.Description));
    }
}
