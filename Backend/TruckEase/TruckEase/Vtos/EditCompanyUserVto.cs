#nullable disable
namespace TruckEase.Vtos;

using TruckEase.ValueObjects;

public class EditCompanyUserVto
{

    public FirstNameValue FirstName { get; set; }

    public LastNameValue LastName { get; set; }

    public string WorkPhone { get; set; }

    public string MobilePhone { get; set; }

}