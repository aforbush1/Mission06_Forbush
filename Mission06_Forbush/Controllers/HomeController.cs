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
            return View("MovieForm");
        }

        // Post Method for receiving information and the method saves form data to the database and displays the "Index" view with that data.
        [HttpPost]
        public IActionResult MovieForm(Application response)
        {
            _context.Applications.Add(response);
            _context.SaveChanges();

            return View("Index", response);
        }
    }
}
