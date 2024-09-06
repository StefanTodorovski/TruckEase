#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TruckEase.Enums;


public class TransportVehicleType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uid")]
    public Guid Uid { get; set; }

    [Column("createdon")]
    public DateTime CreatedOn { get; set; }

    [Column("deletedon")]
    public DateTime DeletedOn { get; set; }

    [Column("createdby")]
    public int CreatedBy { get; set; }

    [Column("vehicletype")]
    public Transport VehicleType { get; set; }

    [Column("transportvehicleid")]
    public int TransportVehicleId { get; set; }
}
