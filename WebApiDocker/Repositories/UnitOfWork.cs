using WebApiDocker.Data;
using WebApiDocker.Interfaces;

namespace WebApiDocker.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
    public void SaveChangesAsync()
    {
        _dbContext.SaveChangesAsync();
    }
}
