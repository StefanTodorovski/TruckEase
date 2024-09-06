#nullable disable
namespace TruckEase.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class ContactCompany
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

    [Column("deactivatedOn")]
    public DateTime? DeactivatedOn { get; set; }

    [Column("companyId")]
    public int CompanyId { get; set; }

    [Column("forCompanyFK")]
    public int ForCompanyFK {  get; set; }


}
