#nullable disable
namespace TruckEase.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TruckEase.Enums;

public class Company
{

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uid")]
    public Guid Uid { get; set; }

    [Column("createdOn")]
    public DateTime CreatedOn { get; set; }

    [Column("deletedOn")]
    public DateTime DeletedOn { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("registrationNumber")]
    public string RegistrationNumber { get; set; }

    [Column("companyType")]
    public CompanyType CompanyType { get; set; }

    [Column("description")]
    public string Description { get; set; }

}
