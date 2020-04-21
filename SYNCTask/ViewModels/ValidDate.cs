using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SYNCTask.ViewModels
{
    public class ValidDate:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var news=(NewsFormViewModel)validationContext.ObjectInstance;
            var date = Convert.ToDateTime(value);
            var x = date-DateTime.Now;
            if (x.Days >= 7)
                return new ValidationResult("This Time is limited for week");

            
       
           

            return ( news.PublicationDate>DateTime.Now) ? ValidationResult.Success : new ValidationResult("This Date in th past");
        }
    }
}