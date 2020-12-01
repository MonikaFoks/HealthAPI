using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthAPI.Controllers
{
    public class WeightController : Controller
    {
        private Context db;

        public WeightController()
        {
            db = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public ActionResult Weight()
        {
            var weights = db.Weights.ToList().Where(p => p.userId == (int)Session["id"]);
            return View(weights);

        }


        public ActionResult Delete(int id)
        {
            var weight = db.Weights.SingleOrDefault(p => p.Id == id);
            db.Weights.Remove(weight);
            db.SaveChanges();

            return RedirectToAction("Weight");
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Save(Weight weight)
        {
            if (ModelState.IsValid)
            {
                weight.userId = (int)Session["id"];
                db.Weights.Add(weight);
                db.SaveChanges();
            }

            return RedirectToAction("Weight");
        }
    }
}