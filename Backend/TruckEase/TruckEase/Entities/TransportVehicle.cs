using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TruckEase.Enums;

namespace TruckEase.Entities;

public class TransportVehicle
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

    [Column("createdBy")]
    public int CreatedBy { get; set; }

    [Column("range")]
    public int Range { get; set; }

    [Column("loadWeight")]
    public double LoadWeight { get; set; }

    [Column("companyId")]
    public int ForCompanyId { get; set; }

    [Column("transportTypeId")]
    public int TransportType { get; set; }

    [Column("fuelType")]
    public FuelType FuelType { get; set; }

}
