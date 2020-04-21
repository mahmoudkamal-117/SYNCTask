using SYNCTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace SYNCTask.Controllers.Api
{
    public class NewsController : ApiController
    {
        private ApplicationDbContext db;
        public NewsController()
        {
            db = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var news = db.News.SingleOrDefault(n => n.Id == id && n.UserId == userId);
            if (news == null)
                return NotFound();
            db.News.Remove(news);
            db.SaveChanges();
            return Ok();
        }
    }
}
