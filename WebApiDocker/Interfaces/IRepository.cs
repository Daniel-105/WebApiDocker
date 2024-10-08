using System.Linq.Expressions;

namespace WebApiDocker.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);

        public T GetById(int Id);

        public IEnumerable<T> GetAll();

        public void Delete(int Id);
        public void Update(T entity);
    }
}
