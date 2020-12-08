using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace HealthAPI.Controllers.Api
{
    public class BloodSugarsController : ApiController
    {
        private Context _context;

        public BloodSugarsController()
        {
            _context = new Context();
        }
        // GET /api/bloodSugars
        public IEnumerable<BloodSugar> GetBloodSugars()
        {
            return _context.BloodSugars.ToList();
        }


        //GET /api/bloodSugars/1
        [HttpGet]
        public BloodSugar GetBloodSugar(int id)
        {
            var bloodSugar = _context.BloodSugars.SingleOrDefault(c => c.Id == id);

            if (bloodSugar == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return bloodSugar;
        }

        //POST /api/bloodSugars
        [HttpPost]
        public BloodSugar CreateBloodSugar(BloodSugar bloodSugar)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.BloodSugars.Add(bloodSugar);
            _context.SaveChanges();

            return bloodSugar;
        }

        // PUT /api/bloodSugars/1
        [HttpPut]
        public void UpdateBloodSugar(int id, BloodSugar bloodSugar)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bloodSugarInDb = _context.BloodSugars.SingleOrDefault(c => c.Id == id);
            if (bloodSugarInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            bloodSugarInDb.userId = bloodSugar.userId;
            bloodSugarInDb.mgdL = bloodSugar.mgdL;
            bloodSugarInDb.Date = bloodSugar.Date;

            _context.SaveChanges();
        }

        //DELETE /api/bloodSugars/1
        [HttpDelete]
        public void DeleteBloodSugar(int id)
        {
            var bloodSugarInDb = _context.BloodSugars.SingleOrDefault(c => c.Id == id);
            if (bloodSugarInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.BloodSugars.Remove(bloodSugarInDb);
            _context.SaveChanges();
        }
    }
}
