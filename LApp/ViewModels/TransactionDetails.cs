using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LApp.ViewModels
{
    public class TransactionDetails
    {
        public string RequestUserName { get; set; }
        public BookViewModel Book { get; set; }
    }
}