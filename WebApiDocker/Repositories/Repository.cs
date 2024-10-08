using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiDocker.Data;
using WebApiDocker.Interfaces;

namespace WebApiDocker.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    public Repository(ApplicationDbContext dbContext, DbSet<T> dbSet)
    {
        _dbContext = dbContext;
        _dbSet = dbSet;

    }
    public void Add(T entity)
    {
        _dbContext.Add(entity);
    }

    public T GetById(int Id)
    {
        return _dbContext.Set<T>().Find(Id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public void Delete(int Id)
    {
        T entity = _dbContext.Set<T>().Find(Id);
        _dbContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Update(entity);
    }
}
