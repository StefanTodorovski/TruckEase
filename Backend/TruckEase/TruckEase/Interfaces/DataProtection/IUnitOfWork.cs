#nullable disable
using TruckEase.Entities;

namespace TruckEase.Interfaces.DataProtection;

public interface IUnitOfWork
{
    IRepository<Company> Companies { get; }

    IRepository<CompanyUser> CompanyUsers { get; }

    IRepository<CompanyEmployee> CompanyEmployees { get; }

    IRepository<ContactCompany> ContactCompanies { get; }

    IRepository<TransportOffer> TransportOffers { get; }

    IRepository<TransportRequest> TransportRequests { get; }

    IRepository<TransportType> TransportTypes { get; }

    IRepository<TransportVehicle> TransportVehicles { get; }

    IRepository<TransportVehicleType> TransportVehicleTypes { get; }


    Task<int> SaveAsync();
}
