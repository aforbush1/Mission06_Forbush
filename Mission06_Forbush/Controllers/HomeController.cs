// Author: Adam Forbush
// Description: Movie Website for Joel Hilton

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Forbush.Models;
using System.Diagnostics;

namespace Mission06_Forbush.Controllers
{
    public class HomeController : Controller
    {
        //Constructor that declares Database Context
        private MovieFormContext _context;

        public HomeController(MovieFormContext temp)
        {
            _context = temp;
        }

        // Route for Index View
        public IActionResult Index()
        {
            return View();
        }

        // Route for GetToKnowJoel View
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Route for MovieForm
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View(new Movie());
        }

        // Post Method for receiving information and the method saves form data to the database and displays the "Confirm" view with that data.
        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Index");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();
                ViewBag.Title = "Error";
                return View(response);
            }

        }

        // Route and Linq for 
        public IActionResult MovieList()
        {

            var movie = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Include(x => x.Category) // Ensure you include the Category if you're using it in the view
                .Single(x => x.MovieId == id);

            // If you need to pass categories to the view for a dropdown, use ViewBag or ViewData
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View("MovieForm", recordToEdit); // Assuming "Edit" is the correct view for editing a Movie
        }

        // HttpPost for Edit Button route
        [HttpPost]
        public IActionResult Edit(Movie update)
        {
            _context.Update(update);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        // HttpGet Route for navigating to the Delete view
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Passing in the id so that we can get the correct MovieId
            var delete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(delete);
        }

        // The HttpPost for actually deleting the record
        [HttpPost]
        public IActionResult Delete(Movie remove)
        {
            // Delete Record
            _context.Movies.Remove(remove);
            _context.SaveChanges();

            // Redirect to the Movie List
            return RedirectToAction("MovieList");
        }
    }
}
