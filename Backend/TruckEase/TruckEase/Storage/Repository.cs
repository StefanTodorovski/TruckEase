using Microsoft.EntityFrameworkCore;
using TruckEase.Data;
using TruckEase.Interfaces.DataProtection;

namespace TruckEase.Storage;

public class Repository<T> : IRepository<T>
      where T : class
{
    public Repository(AppDbContext databaseContext)
    {
        DbContext = databaseContext;
        DbSet = DbContext.Set<T>();
    }

    public DbSet<T> DbSet { get; }

    protected AppDbContext DbContext { get; }

    public IQueryable<T> All()
    {
        return DbSet.IgnoreQueryFilters();
    }

    public IQueryable<T> IgnoreQueryFilters()
    {
        return DbSet.IgnoreQueryFilters();
    }

    /*
    public async Task<T> GetByIdAsync(int id)
    {
        return await All().SingleOrDefaultAsync(f => f.Id == id);
    }
    */

    public void Insert(T entity)
    {
        DbSet.Add(entity);
    }

    public void InsertRange(IEnumerable<T> entities)
    {
        DbSet.AddRange(entities);
    }

    public IQueryable<T> AllNoTracking()
    {
        return All().AsNoTracking();
    }
}
