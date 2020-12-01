using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthAPI.Controllers
{
    public class PressureController : Controller
    {
        private Context db;

        public PressureController()
        {
            db = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public ActionResult Pressure()
        {
            var pressures = db.Pressures.ToList().Where(p => p.userId == (int)Session["id"]);
            return View(pressures);

        }


        public ActionResult Delete(int id)
        {
            var pressure = db.Pressures.SingleOrDefault(p => p.Id == id);
            db.Pressures.Remove(pressure);
            db.SaveChanges();

            return RedirectToAction("Pressure");
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Save(Pressure pressure)
        {
            if (ModelState.IsValid)
            {
                pressure.userId = (int)Session["id"];
                db.Pressures.Add(pressure);
                db.SaveChanges();
            }

            return RedirectToAction("Pressure");
        }
    }
}
