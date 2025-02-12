using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Kehl.Models;

namespace Mission6_Kehl.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext;
        public HomeController(MovieContext temp) //Constructor
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

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            _movieContext.Movies.Add(response); //Add record to database
            _movieContext.SaveChanges();
            return View(response);
        }
    }
}
