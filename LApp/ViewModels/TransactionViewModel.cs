using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LApp.ViewModels
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string IssuedDate { get; set; }
        public string ReturnDate { get; set; }
    }
}