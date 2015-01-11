using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LApp.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string PublishedYear { get; set; }
        public string Author { get; set; }
        public bool IsAvailableInStore { get; set; }
    }
}