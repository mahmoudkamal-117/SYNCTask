using SYNCTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SYNCTask.Controllers
{
    public class AuthorsController : Controller
    {
        private ApplicationDbContext db;
        public AuthorsController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Authors
        public ActionResult Index()
        {
            var author= db.Authors.ToList();
            return View(author);
        }
        [Authorize]
        public ActionResult Create()
        {
            var author = new Author();
            return View("AuthorForm",author);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View("AuthorForm",author);
            }
            if (author.Id == 0)
            {
                db.Authors.Add(author);
                
            }
            else
            {
                var authorInDb = db.Authors.Single(a => a.Id == author.Id);
                authorInDb.Name = author.Name;
            }

            db.SaveChanges();
            return RedirectToAction("Index","Authors");
        }
        public ActionResult Edit(int id)
        {
            var author = db.Authors.SingleOrDefault(c => c.Id == id);
            if (author == null)
                return HttpNotFound();
            return View("AuthorForm", author);
        }
       
    }
}