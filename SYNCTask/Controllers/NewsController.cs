using SYNCTask.Models;
using SYNCTask.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
namespace SYNCTask.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db;
        public NewsController()
        {
            db = new ApplicationDbContext();
        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var news = db.News
                .Where(n => n.UserId == userId)
                .Include(n => n.Author)
                .ToList();
            return View(news);
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewmodel = new NewsFormViewModel
            {
                Authors = db.Authors.ToList(),
                Heading="Add News"
            };
            return View ("NewsForm",viewmodel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]        
        public ActionResult Create(NewsFormViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Authors = db.Authors.ToList();
                return View("NewsForm", viewmodel);
            }
            if (viewmodel.ImageUpload != null)
            {
                var path = Path.Combine(Server.MapPath("~/Images"), viewmodel.ImageUpload.FileName);
                viewmodel.ImageUpload.SaveAs(path);
                viewmodel.Image = viewmodel.ImageUpload.FileName;
                
            }
            //if (viewmodel.ImageUpload != null)
           
            //{
            //    string filename = Path.GetFileNameWithoutExtension(viewmodel.ImageUpload.FileName);
            //    string extension = Path.GetExtension(viewmodel.ImageUpload.FileName);
            //    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            //    viewmodel.Image = "~/Images/" + filename;
            //    filename = Path.Combine(Server.MapPath("~/Images/"), filename);
            //    viewmodel.ImageUpload.SaveAs(filename);
            //}
            var userId = User.Identity.GetUserId();
            var news = new New()
            {
              CreationDate=DateTime.Now,
              Title=viewmodel.Title,
              PublicationDate=viewmodel.PublicationDate,
              Image=viewmodel.Image,
              NewsDescription=viewmodel.NewsDescription,
              AuthorId=viewmodel.Author,
              UserId=userId
              
              

            };
            db.News.Add(news);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var news = db.News.Single(n => n.Id == id && n.UserId == userId);
            
            var viewmodel = new NewsFormViewModel()
            {
                Id=id,
                Authors=db.Authors.ToList(),
                Title =news.Title,
                PublicationDate = news.PublicationDate,
                NewsDescription = news.NewsDescription,
                Author = news.AuthorId,
                Image=news.Image,
                Heading="Edit News"
            };
            return View("NewsForm", viewmodel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(NewsFormViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Authors = db.Authors.ToList();
                return View("NewsForm", viewmodel);
                
            }
            
            var userId = User.Identity.GetUserId();
            var news = db.News
                .Single(n => n.Id == viewmodel.Id && n.UserId == userId);
           
                news.Title = viewmodel.Title;
                news.PublicationDate = viewmodel.PublicationDate;
                news.NewsDescription = viewmodel.NewsDescription;
                news.AuthorId = viewmodel.Author;


                var oldpath = Path.Combine(Server.MapPath("~/Images"), news.Image);
                if (viewmodel.ImageUpload != null)
                {
                    System.IO.File.Delete(oldpath);
                    var path = Path.Combine(Server.MapPath("~/Images"), viewmodel.ImageUpload.FileName);
                    viewmodel.ImageUpload.SaveAs(path);

                    news.Image = viewmodel.ImageUpload.FileName;
                }
                
               
                
                db.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Details(int id)
        {
            var news = db.News.Include(n=>n.Author).SingleOrDefault(n => n.Id == id);

            if (news == null)
                return HttpNotFound();
          
            return View(news);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
             var userId = User.Identity.GetUserId();
             var news = db.News.SingleOrDefault(n => n.Id == id && n.UserId == userId);
             if (news == null)
                 return HttpNotFound();
             db.News.Remove(news);
             db.SaveChanges();
             return RedirectToAction("Mine", "News");
        }
    }
}