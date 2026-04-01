using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class MovieServiceController : Controller
    {
        private readonly IMovieService _service;

        public MovieServiceController(IMovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _service.Add(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _service.Update(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _service.Delete(movie.Id);
            return RedirectToAction("Index");
        }
    }
}