using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext db;
        public MovieController(AppDbContext Context)
        {
            db = Context;
        }
        public IActionResult Index()
        {
            var movies = db.Movies.ToList();
            return View(movies);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var movie = db.Movies.Find(id);
            return View(movie);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            db.Movies.Update(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE GET
        public IActionResult Delete(int id)
        {
            var movie = db.Movies.Find(id);
            return View(movie);
        }

        // DELETE POST
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
