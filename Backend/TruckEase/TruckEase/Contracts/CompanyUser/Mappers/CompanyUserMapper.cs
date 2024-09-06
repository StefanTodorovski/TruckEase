using TruckEase.Contracts.CompanyUser.Requests;
using TruckEase.Contracts.CompanyUser.Responses;
using TruckEase.Dtos;
using TruckEase.ValueObjects;
using TruckEase.Vtos;

namespace TruckEase.Contracts.CompanyUser.Mappers;

public static class CompanyUserMapper
{
    public static RegisterCompanyUserVto ToRegisterCompanyUserVto(this RegisterCompanyUserRequest request)
    {
        return new RegisterCompanyUserVto
        {
            Email = EmailValue.Create(request.Email),
            FirstName = FirstNameValue.Create(request.FirstName),
            LastName = LastNameValue.Create(request.LastName),
            Password = PasswordValue.Create(request.Password),
        };
    }

    public static EditCompanyUserVto ToEditCompanyUserVto(this EditCompanyUserRequest request)
    {
        return new EditCompanyUserVto
        {
            FirstName = FirstNameValue.Create(request.FirstName),
            LastName = LastNameValue.Create(request.LastName),
            WorkPhone = request.WorkPhone,
            MobilePhone = request.MobilePhone
        };
    }

    public static LoginCompanyUserVto ToLoginCompanyUserVto(this LoginRequest request)
    {
        return new LoginCompanyUserVto
        {
            Email = request.Email,
            Password = request.Password,
        };
    }

    public static RegisterCompanyUserWithTokenResponse ToRegisteredCompanyUserResponseWithToken(this RegisterCompanyUserWithTokenDto companyUserDto)
    {
        return new RegisterCompanyUserWithTokenResponse
        {
            FirstName = companyUserDto.FirstName,
            LastName = companyUserDto.LastName,
            Email = companyUserDto.Email,
            IsUserInCompany = companyUserDto.IsUserInCompany,
            Token = companyUserDto.Token
        };
    }

    public static RegisterCompanyUserResponse ToRegisteredCompanyUserResponse(this RegisterCompanyUserDto companyUserDto)
    {
        return new RegisterCompanyUserResponse
        {
            FirstName = companyUserDto.FirstName,
            LastName = companyUserDto.LastName,
            Email = companyUserDto.Email,
            IsUserInCompany = companyUserDto.IsUserInCompany,
        };
    }

    public static CompanyUserInfoResponse ToCompanyUserInfoResponse(this CompanyUserInfoDto companyUserDto)
    {
        return new CompanyUserInfoResponse(
            companyUserDto.FirstName,
            companyUserDto.LastName,
            companyUserDto.Email,
            companyUserDto.JobTitle,
            companyUserDto.WorkPhone,
            companyUserDto.MobilePhone);
    }

}
