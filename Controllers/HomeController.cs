using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HealthAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetUser()
        {
            using(Context db = new Context())
            {
                List<User> users = db.Users.ToList<User>();
                var json = JsonConvert.SerializeObject(users);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
             
        }

        public JsonResult GetPulse()
        {
            using (Context db = new Context())
            {
                List<Pulse> pulses = db.Pulses.ToList<Pulse>();
                var json = JsonConvert.SerializeObject(pulses);
                return Json(json, JsonRequestBehavior.AllowGet);
            }

        }
    }
}