using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthAPI.Controllers
{
    public class PulseController : Controller
    {
        private Context db;

        public PulseController()
        {
            db = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public ActionResult Pulse()
        {
            var pulses = db.Pulses.ToList().Where(p => p.userId == (int) Session["id"]);
            return View(pulses);

        }


        public ActionResult Delete(int id)
        {
            var pulse = db.Pulses.SingleOrDefault(p => p.Id == id);
            db.Pulses.Remove(pulse);
            db.SaveChanges();

            return RedirectToAction("Pulse");
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Save(Pulse pulse)
        {
            if (ModelState.IsValid)
            {
                pulse.userId = (int)Session["id"];
                db.Pulses.Add(pulse);
                db.SaveChanges();
            }

            return RedirectToAction("Pulse");
        }
    }
}