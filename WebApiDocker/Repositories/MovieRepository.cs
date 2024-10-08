using System.Linq.Expressions;
using WebApiDocker.Data;
using WebApiDocker.Interfaces;

namespace WebApiDocker.Repositories;
public class MovieRepository : IRepository<Movie>
{
    private readonly ApplicationDbContext _dbContext;
    public MovieRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Movie entity)
    {
        _dbContext.Add(entity);
    }
    public Movie GetById(int Id)
    {
        return _dbContext.Movies.Find(Id);
    }

    public IEnumerable<Movie> GetAll()
    {
        IEnumerable<Movie> entities = new List<Movie>();

        List<Movie> result = _dbContext.Set<Movie>().ToList();
        return result;
    }

    public void Delete(int Id)
    {
        Movie movie = _dbContext.Movies.Find(Id);
        _dbContext.Movies.Remove(movie);
    }
}
