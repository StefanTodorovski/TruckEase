using Microsoft.EntityFrameworkCore;

namespace TruckEase.Interfaces.DataProtection;

public interface IRepository<T>
    where T : class
{
    DbSet<T> DbSet { get; }

    IQueryable<T> All();

    IQueryable<T> IgnoreQueryFilters();

//    Task<T> GetByUidAsync(Guid uid);

 //  Task<T> GetByIdAsync(int id);

    void Insert(T entity);

    void InsertRange(IEnumerable<T> entities);

    IQueryable<T> AllNoTracking();
}
