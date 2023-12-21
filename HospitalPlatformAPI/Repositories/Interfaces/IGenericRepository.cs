using System.Linq.Expressions;

namespace HospitalPlatformAPI.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<T> GetByPredicateAsync(Func<T, bool> func);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    bool Any(Func<T, bool> func);
    List<T> Where(Func<T, bool> func);
    IQueryable Queryable();
    IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
    IQueryable<T> IncludeThen(params Expression<Func<T, object>>[] includes);
}