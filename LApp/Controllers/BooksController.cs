using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LApp.Filters;
using LApp.ViewModels;
using LApp.Models;

namespace LApp.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/
        LAppContext dbContext;
        public BooksController()
        {
            dbContext = new LAppContext();
        }

        //Private
        private User UserData
        {
            get
            {
                return Session["User"] as User;
            }
            set
            {
                Session["User"] = value;
            }
        }

        public ActionResult Index()
        {
            ViewBooksViewModel vm = new ViewBooksViewModel();
            vm.UserName = UserData.Name;
            vm.UserRole = UserData.Role;
            vm.Books = new List<BookViewModel>();
            
            foreach(var book in dbContext.Books)
            {
                vm.Books.Add(new BookViewModel() { Author = book.Author, BookId = book.BookId, IsAvailableInStore = book.IsAvailableInStore, Name = book.Name, PublishedYear = book.PublishedYear });
            }

            return View(vm);
        }

        public ActionResult ViewBook(int id)
        {
            ViewBookViewModel vm = new ViewBookViewModel();
            vm.UserName = UserData.Name;
            vm.UserRole = UserData.Role;
            Book book = dbContext.Books.Find(id);

            vm.Book = new BookViewModel() { BookId = book.BookId, PublishedYear = book.PublishedYear, Name = book.Name, Author = book.Author, IsAvailableInStore = book.IsAvailableInStore };
            return View(vm);
        }

        public ActionResult AddBook()
        {
            AddBookViewModel vm = new AddBookViewModel();
            vm.UserName = UserData.Name;
            return View(vm);
        }

        public ActionResult IssueBook()
        {
            IssueBookViewModel vm = new IssueBookViewModel();
            vm.UserName = UserData.Name;
            vm.Requests = new List<TransactionViewModel>();

            foreach (var trans in dbContext.Transactions)
            {
                if(string.IsNullOrEmpty(trans.IssuedDate))
                    vm.Requests.Add(new TransactionViewModel() { TransactionId = trans.TransactionId, BookId = trans.BookId, UserId = trans.UserId });
            }

            return View(vm);
        }

        public ActionResult ReturnBook()
        {
            ReturnBookViewModel vm = new ReturnBookViewModel();
            vm.UserName = UserData.Name;
            vm.Books = new List<BookViewModel>();

            foreach (var book in dbContext.Books)
            {
                if(!book.IsAvailableInStore)
                    vm.Books.Add(new BookViewModel() { Author = book.Author, BookId = book.BookId, IsAvailableInStore = book.IsAvailableInStore, Name = book.Name, PublishedYear = book.PublishedYear });
            }

            return View(vm);
        }
        //Http Post
        [HttpPost]
        public string AddBook(string name, string author, string publishedYear)
        {
            try
            {
                Book book = new Book();
                book.Name = name;
                book.Author = author;
                book.PublishedYear = publishedYear;
                book.IsAvailableInStore = true;
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
                return "success";
            }
            catch(Exception ex)
            {
                return "Please try later";
            }
        }

        [HttpPost]
        public string RequestBook(int id)
        {
            try
            {
                Transaction trans = new Transaction();
                trans.BookId = id;
                trans.UserId = UserData.UserId;
                dbContext.Transactions.Add(trans);
                dbContext.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return "Please try later";
            }
            return "";
        }

        [HttpPost]
        public string IssueBook(int id)
        {
            try
            {
                //find it in DB
                Transaction tran = dbContext.Transactions.Find(id);
                
                if(tran == null)
                    return "Please try later";

                tran.IssuedDate = DateTime.Now.ToShortDateString();

                dbContext.Entry(tran).State = System.Data.Entity.EntityState.Modified;
                
                Book book = dbContext.Books.Find(tran.BookId);
                book.IsAvailableInStore = false;
                dbContext.Entry(book).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return "Please try later";
            }            
        }

        [HttpPost]
        public JsonResult GetTransactionDetails(int id)
        {
            try
            {
                Transaction trans = dbContext.Transactions.Find(id);
                Book book = dbContext.Books.Find(trans.BookId);
                User user = dbContext.Users.Find(trans.UserId);

                TransactionDetails vm = new TransactionDetails() { RequestUserName = user.Name, Book = new BookViewModel() { BookId = book.BookId, Author = book.Author, IsAvailableInStore = book.IsAvailableInStore, Name = book.Name, PublishedYear = book.PublishedYear } };
                return Json(vm);
            }
            catch (Exception ex)
            {
                return Json("No transaction");
            }
        }

        [HttpPost]
        public string ReturnBook(int id)
        {
            try
            {
                //find it in DB
                Transaction tran = dbContext.Transactions.Where(x => x.BookId == id && string.IsNullOrEmpty(x.ReturnDate)).FirstOrDefault();

                if (tran == null)
                    return "Please try later";

                tran.ReturnDate = DateTime.Now.ToShortDateString();

                dbContext.Entry(tran).State = System.Data.Entity.EntityState.Modified;

                Book book = dbContext.Books.Find(tran.BookId);
                book.IsAvailableInStore = true;
                dbContext.Entry(book).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return "Please try later";
            }
        }
    }
}
