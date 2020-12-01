using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthAPI.Controllers
{
    public class PressureController : Controller
    {
        // GET: Pressure
        public ActionResult Pressure()
        {
            return View();
        }
    }
}