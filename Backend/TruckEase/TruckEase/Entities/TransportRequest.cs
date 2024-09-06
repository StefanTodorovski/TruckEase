#nullable disable
namespace TruckEase.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TruckEase.Enums;


public class TransportRequest
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

    [Column("description")]
    public string Description {  get; set; }

    [Column("startTime")]
    public DateTime StartTime {  get; set; }

    [Column("arrivalTime")]
    public DateTime ArrivalTime {  get; set; }

    [Column("price")]
    public double Price {  get; set; }

    [Column("startLocation")]
    public string StartLocation {  get; set; }

    [Column("destination")]
    public string Destination {  get; set; }

    [Column("loadWeight")]
    public double LoadWeight { get; set; }

    [Column("isExpress")]
    public bool IsExpress { get; set; }

    [Column("isOpenRequest")]
    public bool IsOpenRequest {  get; set; }

    [Column("isDraft")]
    public bool IsDraft {  get; set; }

    [Column("companyId")]
    public int CompanyId {  get; set; }

    [Column("transportType")]
    public Transport TransportType { get; set; }

    [Column("transportStatus")]
    public TransportStatus TransportStatus { get; set; }

}
