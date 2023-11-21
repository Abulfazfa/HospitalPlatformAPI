using System.Linq.Expressions;
using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalPlatformAPI.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    private readonly AppDbContext _appDbContext;
    public GenericRepository(AppDbContext dbContext)
    {
        _appDbContext = dbContext;
        _dbSet = _appDbContext.Set<T>();
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<List<T>> GetAllAsync(Expression<Func<T, object>>[] include)
    {
        return await _dbSet.Include(include).ToListAsync();
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await Task.CompletedTask;
    }

    public IQueryable GetByPredicateAsync(Func<T> func, Expression<Func<T, object>>[] includes = null)
    {
        var query = _dbSet.AsQueryable();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }
    public bool Any(Func<T, bool> func)
    {
        return _dbSet.Any(func);
    }

    public List<T> Where(Func<T, bool> func)
    {
        return _dbSet.Where(func).ToList();
    }
    public IQueryable Queryable()
    {
        return _dbSet.AsQueryable();
    }
}