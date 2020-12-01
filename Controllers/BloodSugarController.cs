using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthAPI.Controllers
{
    public class BloodSugarController : Controller
    {
        private Context db;

        public BloodSugarController()
        {
            db = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public ActionResult BloodSugar()
        {
            var bloodSugars = db.BloodSugars.ToList().Where(p => p.userId == (int)Session["id"]);
            return View(bloodSugars);

        }


        public ActionResult Delete(int id)
        {
            var bloodSugar = db.BloodSugars.SingleOrDefault(p => p.Id == id);
            db.BloodSugars.Remove(bloodSugar);
            db.SaveChanges();

            return RedirectToAction("BloodSugar");
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Save(BloodSugar bloodSugar)
        {
            if (ModelState.IsValid)
            {
                bloodSugar.userId = (int)Session["id"];
                db.BloodSugars.Add(bloodSugar);
                db.SaveChanges();
            }

            return RedirectToAction("BloodSugar");
        }
    }
}