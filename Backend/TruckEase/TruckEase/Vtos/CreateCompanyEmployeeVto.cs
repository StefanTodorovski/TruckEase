#nullable disable
namespace TruckEase.Vtos;

using TruckEase.Enums;
using TruckEase.ValueObjects;


public class CreateCompanyEmployeeVto
{
    public EmailValue Email { get; set; }

    public FirstNameValue FirstName { get; set; }

    public LastNameValue LastName { get; set; }

    public EmployeeType EmployeeType { get; set; }

}