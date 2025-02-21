using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission6_Kehl.Models;

namespace Mission6_Kehl.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _movieContext;

        public HomeController(MovieContext temp) // Constructor
        {
            _movieContext = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GettoKnowJoel()
        {
            return View();
        }

        // ✅ Show form to add a new movie
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = new SelectList(_movieContext.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // ✅ Add movie to database and redirect to ViewMovies
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid) // Validate inputs
            {
                _movieContext.Movies.Add(response);
                _movieContext.SaveChanges();
                return RedirectToAction("ViewMovies"); // Redirect instead of returning view
            }

            ViewBag.Categories = new SelectList(_movieContext.Categories, "CategoryId", "CategoryName");
            return View(response); // Show form again if invalid
        }

        // ✅ Fetch all movies from database and display them
        public IActionResult ViewMovies()
        {
            var movies = _movieContext.Movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        // ✅ Show the edit form with existing movie data
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _movieContext.Movies.Find(id);
            if (movie == null)
            {
                return RedirectToAction("ViewMovies"); // Redirect instead of showing an error
            }

            // 🔹 Pass ViewBag.Categories so dropdown works in EditMovie.cshtml
            ViewBag.Categories = new SelectList(_movieContext.Categories, "CategoryId", "CategoryName", movie.CategoryId);

            return View(movie);
        }

        // ✅ Update the movie details
        [HttpPost]
        public IActionResult EditMovie(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Movies.Update(updatedMovie);
                _movieContext.SaveChanges();
                return RedirectToAction("ViewMovies");
            }

            // 🔹 Pass ViewBag.Categories again if form submission fails
            ViewBag.Categories = new SelectList(_movieContext.Categories, "CategoryId", "CategoryName", updatedMovie.CategoryId);
            return View(updatedMovie);
        }

        // ✅ Show a confirmation page before deleting (optional)
        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieContext.Movies.Find(id);
            if (movie == null)
            {
                return RedirectToAction("ViewMovies");
            }
            return View(movie);
        }

        // ✅ Delete the movie from the database
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var movie = _movieContext.Movies.Find(id);
            if (movie != null)
            {
                _movieContext.Movies.Remove(movie);
                _movieContext.SaveChanges();
            }

            return RedirectToAction("ViewMovies");
        }
    }
}
