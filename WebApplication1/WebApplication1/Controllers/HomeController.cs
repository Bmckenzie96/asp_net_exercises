using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movieList = _context.Movies.Include(m => m.Genre).ToList();
            return View(movieList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("Home/MovieForm")]
        public ViewResult MovieForm()
        {
            var viewModel = new MovieFormVM()
            {
                Movie = new Movie(),
                GenreList = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public RedirectToRouteResult Save(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}