using System;
using GigHub.Models;
using GigHub.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        /*[ValidateAntiForgeryToken]*/
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Generes = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //Mule
                viewModel.Generes = _context.Genres.ToList();
                return View("Create", viewModel);
            } // the following two lines are bad code as they go back to the database
            // Genres and Artist are navigational property so we need to add foreign key
            //var artist = _context.Users.Single(u => u.Id == User.Identity.GetUserId());
            // b/c the drop down captured the id of the genre
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            var gig = new Gig
            {
                //Artist = artist,
                ArtistId = User.Identity.GetUserId(), // this will return the id of the current user
                //DateTime = DateTime.Parse($"{viewModel.Date}{viewModel.Time}"),
                DateTime = viewModel.GetDateTime(), //string.Format("{0}{1}",viewModel.Date,viewModel.Time)),
                Venue = viewModel.Venue,
                //Genre = genre
                GenreId = byte.Parse(viewModel.Genre.ToString())
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}