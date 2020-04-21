using SYNCTask.Controllers;
using SYNCTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace SYNCTask.ViewModels
{
    public class NewsFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string NewsDescription { get; set; }

        [Required]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        

        [ValidDate]
        public DateTime? PublicationDate { get; set; }

        public DateTime? CreationDate { get; set; }

        public IEnumerable<Author> Authors { get; set; }
        [Required]
        public int Author { get; set; }
        public string Heading { get; set; }

      
        public string Action
        {
            get
            {
                Expression<Func<NewsController, ActionResult>>
                    update = (c => c.Update(this));

                Expression<Func<NewsController, ActionResult>>
                    create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }



        }
        public NewsFormViewModel()
        {
            if (Image == null)
            {
                Image = "camerashot.png";
            }
            
        }
    }
}