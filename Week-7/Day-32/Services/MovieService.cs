using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.Services;

namespace WebApplication2.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _repository.GetAll();
        }

        public Movie GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Movie movie)
        {
            _repository.Add(movie);
        }

        public void Update(Movie movie)
        {
            _repository.Update(movie);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}