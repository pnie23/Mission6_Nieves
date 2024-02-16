using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Nieves.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Nieves.Controllers
{
    public class HomeController : Controller
    {
        private SubmitFilmContext _context;

        public HomeController(SubmitFilmContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SubmitFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitFilm(FilmSubmission response)
        {
            //Instead of routing to an error page, the form is checked to see if it is completed properly
            //If not, the page will display an error saying that the form is missing required fields.
            //The user can then fix their input, rather than have to go back to another page
            //If the data is correct, then it will submit properly to the database
            if (!ModelState.IsValid)
            {
                ViewBag.showInvalidSubmission = true;
                return View();
            }

            else {
                _context.FilmCollection.Add(response); //Add record to database
                _context.SaveChanges();

                return View("FilmSubmitConfirmation", response);
            }
        }
    }
}
