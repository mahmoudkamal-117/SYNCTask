using SYNCTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SYNCTask.Controllers.api
{
    public class AuthorsController : ApiController
    {
        private ApplicationDbContext db;
        public AuthorsController()
        {
            db = new ApplicationDbContext();
        }

        //Get/api/customers
        public IEnumerable<Author> GetAuthors()
        {
            return db.Authors.ToList();
        }
        [HttpDelete]
        public void DeleteAuthor(int id)
        {
            var authorInDb = db.Authors.SingleOrDefault(c => c.Id == id);
            if (authorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.Authors.Remove(authorInDb);
            db.SaveChanges();
        }
    }
}
