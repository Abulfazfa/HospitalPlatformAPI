using System.Linq.Expressions;

namespace HospitalPlatformAPI.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<T> GetByPredicateAsync(Func<T, bool> func, Expression<Func<T, object>> include = null);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, object>> include);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    bool Any(Func<T, bool> func);
    List<T> Where(Func<T, bool> func);
    IQueryable Queryable();
}