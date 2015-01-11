using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LApp.ViewModels
{
    public class IssueBookViewModel
    {
        public string UserName { get; set; }
        public List<TransactionViewModel> Requests { get; set; }
    }
}