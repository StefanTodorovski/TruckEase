namespace TruckEase.Dtos;

using TruckEase.Enums;


public class CompanyInfoDto
{
    public CompanyInfoDto(int id, string name, string registrationNumber, string companyType, string description)
    {
        Id = id;
        Name = name;
        RegistrationNumber = registrationNumber;
        CompanyType = companyType;
        Description = description;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string RegistrationNumber { get; set; }

    public string CompanyType { get; set; }

    public string Description { get; set; }

}