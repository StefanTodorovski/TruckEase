#nullable disable
using TruckEase.Data;
using TruckEase.Entities;
using TruckEase.Interfaces.DataProtection;

namespace TruckEase.Storage;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext databaseContext;

    private bool disposedValue;

    private IRepository<Company> companiesValue;

    private IRepository<CompanyUser> companyUsersValue;

    private IRepository<CompanyEmployee> companyEmployeesValue;

    private IRepository<ContactCompany> contactCompaniesValue;

    private IRepository<TransportOffer> transportOffersValue;

    private IRepository<TransportRequest> transportRequestsValue;

    private IRepository<TransportType> transportTypesValue;

    private IRepository<TransportVehicle> transportVehiclesValue;

    private IRepository<TransportVehicleType> transportVehicleTypesValue;

    public UnitOfWork(AppDbContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public IRepository<Company> Companies
    {
        get
        {
            if (companiesValue == null)
            {
                companiesValue = new Repository<Company>(databaseContext);
            }

            return companiesValue;
        }
    }

    public IRepository<CompanyUser> CompanyUsers
    {
        get
        {
            if (companyUsersValue == null)
            {
                companyUsersValue = new Repository<CompanyUser>(databaseContext);
            }

            return companyUsersValue;
        }
    }

    public IRepository<CompanyEmployee> CompanyEmployees
    {
        get
        {
            if (companyEmployeesValue == null)
            {
                companyEmployeesValue = new Repository<CompanyEmployee>(databaseContext);
            }

            return companyEmployeesValue;
        }
    }

    public IRepository<ContactCompany> ContactCompanies
    {
        get
        {
            if (contactCompaniesValue == null)
            {
                contactCompaniesValue = new Repository<ContactCompany>(databaseContext);
            }

            return contactCompaniesValue;
        }
    }

    public IRepository<TransportOffer> TransportOffers
    {
        get
        {
            if (transportOffersValue == null)
            {
                transportOffersValue = new Repository<TransportOffer>(databaseContext);
            }

            return transportOffersValue;
        }
    }

    public IRepository<TransportRequest> TransportRequests
    {
        get
        {
            if (transportRequestsValue == null)
            {
                transportRequestsValue = new Repository<TransportRequest>(databaseContext);
            }

            return transportRequestsValue;
        }
    }

    public IRepository<TransportType> TransportTypes
    {
        get
        {
            if (transportTypesValue == null)
            {
                transportTypesValue = new Repository<TransportType>(databaseContext);
            }

            return transportTypesValue;
        }
    }

    public IRepository<TransportVehicle> TransportVehicles
    {
        get
        {
            if (transportVehiclesValue == null)
            {
                transportVehiclesValue = new Repository<TransportVehicle>(databaseContext);
            }

            return transportVehiclesValue;
        }
    }

    public IRepository<TransportVehicleType> TransportVehicleTypes
    {
        get
        {
            if (transportVehicleTypesValue == null)
            {
                transportVehicleTypesValue = new Repository<TransportVehicleType>(databaseContext);
            }

            return transportVehicleTypesValue;
        }
    }


    public async Task<int> SaveAsync()
    {
        return await databaseContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                databaseContext.Dispose();
            }

            disposedValue = true;
        }
    }

}
