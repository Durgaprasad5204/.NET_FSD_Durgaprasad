using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}