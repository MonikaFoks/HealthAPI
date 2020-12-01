using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthAPI.Controllers
{
    public class WeightController : Controller
    {
        // GET: Weight
        public ActionResult Weight()
        {
            return View();
        }
    }
}