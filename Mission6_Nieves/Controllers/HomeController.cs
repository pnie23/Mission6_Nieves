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
                _context.JoelHiltonMovieCollection.Add(response); //Add record to database
                _context.SaveChanges();

                return View("FilmSubmitConfirmation", response);
            }
        }

        public IActionResult CollectionView()
        {
            var collection = _context.JoelHiltonMovieCollection
                .Include(x => x.Category)
                .ToList();

            return View(collection);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.JoelHiltonMovieCollection
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("SubmitFilm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(FilmSubmission updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("CollectionView");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.JoelHiltonMovieCollection
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(FilmSubmission filmSubmission)
        {
            _context.JoelHiltonMovieCollection.Remove(filmSubmission);
            _context.SaveChanges();

            return RedirectToAction("CollectionView");
        }
    }
}
