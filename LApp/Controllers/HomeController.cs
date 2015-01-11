using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LApp.Filters;
using LApp.Models;

namespace LApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        LAppContext dbContext;
        public HomeController()
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
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        //Post
        [HttpPost]
        public string Login(string userName, string password)
        {
            try
            {
                User user = dbContext.Users.Where(a => a.Email == userName && a.Password == password).FirstOrDefault();
                                
                if (user == null)
                    return "User name or password wrong";

                UserData = user;
                return "success";
            }
            catch (Exception ex)
            {
                return "User name or password wrong";
            }
        }

        [HttpPost]
        public string Register(string name, string email, string password)
        {
            try
            {
                User user = new User();
                user.Name = name;
                user.Email = email;
                user.Password = password;
                //user.Role = "Admin";
                user.Role = "User";

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                UserData = user;
                return "success";
            }
            catch (Exception ex)
            {
                return "User Not created try again";
            }
        }
    }
}
