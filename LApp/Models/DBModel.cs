using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string PublishedYear { get; set; }
        public string Author { get; set; }
        public int RequestedUserId { get; set; }
        public bool IsAvailableInStore { get; set; }
    }
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string IssuedDate { get; set; }
        public string ReturnDate { get; set; }
    }

}