using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LApp.ViewModels
{
    public class ViewBooksViewModel
    {
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public List<BookViewModel> Books { get; set; }
    }
}