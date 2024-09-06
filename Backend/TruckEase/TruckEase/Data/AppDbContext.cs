namespace TruckEase.Data;

using Microsoft.EntityFrameworkCore;
using TruckEase.Entities;

public class AppDbContext : DbContext
{
 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Company> Company { get; set; }

    public DbSet<CompanyEmployee> CompanyEmployee { get; set; }

    public DbSet<CompanyUser> CompanyUser { get; set; }

    public DbSet<ContactCompany> ContactCompany { get; set; }

    public DbSet<TransportOffer> TransportOffer { get; set; }

    public DbSet<TransportRequest> TransportRequest {  get; set; }

    public DbSet<TransportType> TransportType { get; set; }

    public DbSet<TransportVehicle> TransportVehicle { get; set; }

    public DbSet<TransportVehicleType> TransportVehicleType { get; set; }

}
