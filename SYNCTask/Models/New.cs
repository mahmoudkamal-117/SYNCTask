using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SYNCTask.Models
{
    public class New
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

       

        public DateTime? PublicationDate { get; set; }

        public DateTime? CreationDate {  get;  set; }

        public Author Author { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public ApplicationUser User { get; set; }
        
        public string UserId { get; set; }
       

    }
}