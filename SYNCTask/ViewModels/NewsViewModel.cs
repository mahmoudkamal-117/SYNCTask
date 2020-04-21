using SYNCTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SYNCTask.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<New> UpcomingNews { get; set; }
    }
}