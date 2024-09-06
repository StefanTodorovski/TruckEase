using TruckEase.Contracts.CompanyEmployee.Requests;
using TruckEase.Contracts.CompanyEmployee.Responses;
using TruckEase.Contracts.CompanyUser.Requests;
using TruckEase.Dtos;
using TruckEase.ValueObjects;
using TruckEase.Vtos;

namespace TruckEase.Contracts.CompanyEmployee.Mappers;


public static class CompanyEmployeeMapper
{

    public static CreateCompanyEmployeeVto ToCreateCompanyEmployeeVto(this CreateCompanyEmployeeRequest request)
    {
        return new CreateCompanyEmployeeVto
        {
            Email = EmailValue.Create(request.Email),
            FirstName = FirstNameValue.Create(request.FirstName),
            LastName = LastNameValue.Create(request.LastName),
            EmployeeType = request.EmployeeType,
        };
    }

    public static EmployeeInfoResponse ToEmployeeInfoResponse(this EmployeeInfoDto request)
    {
        return new EmployeeInfoResponse
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            EmployeeType = request.EmployeeType
        };
    }
}