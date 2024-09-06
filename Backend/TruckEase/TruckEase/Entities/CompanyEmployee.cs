#nullable disable
namespace TruckEase.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TruckEase.Enums;
public class CompanyEmployee
{

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uid")]
    public Guid Uid { get; set; }

    [Column("createdOn")]
    public DateTime CreatedOn { get; set; }

    [Column("deletedOn")]
    public DateTime? DeletedOn { get; set; }

    [Column("createdBy")]
    public int CreatedBy { get; set; }

    [Column("email")]
    public string Email { get; set; }


    [Column("firstName")]
    public string FirstName { get; set; }

    [Column("lastName")]
    public string LastName { get; set; }

    [Column("employeeType")]
    public EmployeeType EmployeeType {  get; set; }

    [Column("inCompanyFK")]
    public int InCompanyFK { get; set; }

    [Column("userId")]
    public int? UserId { get; set; }
}
