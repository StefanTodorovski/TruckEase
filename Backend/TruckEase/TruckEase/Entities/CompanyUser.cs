#nullable disable
namespace TruckEase.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


public class CompanyUser
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

    [Column("email")]
    public string Email { get; set; }

    [Column("firstName")]
    public string FirstName { get; set; }

    [Column("lastName")]
    public string LastName { get; set; }

    [Column("passwordHash")]
    public string PasswordHash { get; set; }

    [Column("passwordSalt")]
    public string PasswordSalt { get; set; }

    [Column("isVerified")]
    public bool IsVerified { get; set; }

    [Column("jobTitle")]
    public string? JobTitle { get; set; }

    [Column("workPhone")]
    public string? WorkPhone { get; set; }

    [Column("mobilePhone")]
    public string? MobilePhone { get; set; }

    [Column("inCompanyFK")]
    public int? InCompanyFK { get; set; }

}
