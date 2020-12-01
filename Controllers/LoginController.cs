using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            using (Context db = new Context())
            {
                var userDetails = db.Users.Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    return View("Login", user);
                }
                else
                {
                    Session["login"] = userDetails.Login;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddUser(User user)
        {
            using (Context db = new Context())
            {
                var userDetails = db.Users.Where(x => x.Login == user.Login).FirstOrDefault();
                if (userDetails == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["login"] = userDetails.Login; 
                    return RedirectToAction("Register", "Login");
                }
            }
        }
    }
} 