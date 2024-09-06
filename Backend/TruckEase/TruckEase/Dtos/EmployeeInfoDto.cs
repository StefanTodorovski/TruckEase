namespace TruckEase.Dtos;

public class EmployeeInfoDto
{
    public EmployeeInfoDto(string firstName, string lastName, string email, string employeeType)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        EmployeeType = employeeType;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string EmployeeType { get; set; }
}