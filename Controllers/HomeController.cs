﻿using GigHub.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.ViewModels;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upComingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g=>g.Genre).ToList();
                /*.Where(g => g.DateTime < DateTime.Now).ToList();*/

                var viewModel = new GigsVeiwModel
                {
                    UpcomingGigs= upComingGigs,
                    ShowActions= User.Identity.IsAuthenticated,
                    Heading = "Upcoming Gigs"
                };
            return View("Gigs",viewModel);
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
    }
}