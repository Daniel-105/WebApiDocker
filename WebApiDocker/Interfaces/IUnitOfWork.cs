using WebApiDocker.Data;

namespace WebApiDocker.Interfaces;
public interface IUnitOfWork
{
    public void SaveChanges();
    public void SaveChangesAsync();
}
