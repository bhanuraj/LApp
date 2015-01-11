using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LApp.ViewModels
{
    public class ViewBookViewModel
    {
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public BookViewModel Book { get; set; }
    }
}