using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TruckEase.Enums;

namespace TruckEase.Entities;

public class TransportType
{
    public TransportType(
    int id,
    Guid uid,
    DateTime createdOn,
    DateTime deletedOn,
    Transport type,
    int transportRequestId)
    {
        Id = id;
        Uid = uid;
        CreatedOn = createdOn;
        DeletedOn = deletedOn;
        Type = type;
        TransportRequestId = transportRequestId;
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uid")]
    public Guid Uid { get; set; }

    [Column("createdOn")]
    public DateTime CreatedOn { get; set; }

    [Column("deletedOn")]
    public DateTime DeletedOn { get; set; }

    [Column("transportType")]
    public Transport Type {  get; set; }

    [Column("transportRequesterId")]
    public int TransportRequestId {  get; set; }


}
