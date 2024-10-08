using Microsoft.AspNetCore.Mvc;
using WebApiDocker.Interfaces;

namespace WebApiDocker.Controllers;
    [ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly IRepository<Movie> _movieRepository;
    private readonly IUnitOfWork _unitOfWork;
    public MovieController(IRepository<Movie> movieRepostiory, IUnitOfWork unitOfWork)
    {
        _movieRepository = movieRepostiory;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("GetAllMovies")]
    public List<Movie> GetAllMovies()
    {
        List<Movie> movies = _movieRepository.GetAll().ToList();
        return movies;
    }

    [HttpGet("GetMovieById")]
    public Movie GetMovieById(int Id)
    {
        Movie movieById = _movieRepository.GetById(Id);
        return movieById;
    }

    [HttpPost]
    public Movie Post(Movie movie)
    {
        _movieRepository.Add(movie);
        _unitOfWork.SaveChanges();
        return movie;
    }
    [HttpDelete]
    public void DeleteById(int Id)
    {
        _movieRepository.Delete(Id);
        _unitOfWork.SaveChanges();
    }

    [HttpPut]
    public Movie UpdateMovie(Movie movie)
    {
        _movieRepository.Update(movie);
        _unitOfWork.SaveChanges();
        return movie;
    }
}
