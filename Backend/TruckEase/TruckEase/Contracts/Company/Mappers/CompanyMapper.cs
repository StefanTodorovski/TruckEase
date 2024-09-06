using TruckEase.Contracts.Company.Responses;
using TruckEase.Dtos;

namespace TruckEase.Contracts.Company.Mappers;

public static class CompanyMapper
{
    public static CompanyResponse ToCompanyInfoResponse(this CompanyInfoDto contactCompany)
    {
        return new CompanyResponse(
            contactCompany.Id,
            contactCompany.Name,
            contactCompany.RegistrationNumber,
            contactCompany.CompanyType,
            contactCompany.Description);
    }
}
