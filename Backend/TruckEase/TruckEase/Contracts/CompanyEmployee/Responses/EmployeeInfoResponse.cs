#nullable disable
namespace TruckEase.Contracts.CompanyEmployee.Responses;

using TruckEase.Enums;
public class EmployeeInfoResponse
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string EmployeeType { get; set; }

}