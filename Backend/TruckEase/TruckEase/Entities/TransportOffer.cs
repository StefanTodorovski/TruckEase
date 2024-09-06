namespace TruckEase.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TruckEase.Enums;
public class TransportOffer
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

    [Column("additionalInfo")]
    public string? AdditionalInfo {  get; set; }

    [Column("companyOffererId")]
    public int CompanyOffererId {  get; set; }

    [Column("transportRequestId")]
    public int TransportRequestId { get; set; }

    [Column("price")]
    public double? Price { get; set; }

    [Column("status")]
    public OfferStatus Status { get; set; }

}
