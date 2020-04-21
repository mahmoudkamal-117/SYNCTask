using SYNCTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SYNCTask.ViewModels;

namespace SYNCTask.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingnews = db.News
               .ToList();

            //var viewmodel = new NewsViewModel()
            //{
            //    UpcomingNews = upcomingnews

            //};
            return View("Index",upcomingnews);
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