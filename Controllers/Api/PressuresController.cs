using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HealthAPI.Controllers.Api
{
    public class PressuresController : ApiController
    {
        private Context _context;

        public PressuresController()
        {
            _context = new Context();
        }
        // GET /api/pressures
        public IEnumerable<Pressure> GetPressures()
        {
            return _context.Pressures.ToList();
        }

        [HttpGet]
        //GET /api/pressures/1
        public Pressure GetPressure(int id)
        {
            var pressure = _context.Pressures.SingleOrDefault(c => c.Id == id);

            if (pressure == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return pressure;
        }

        //POST /api/pressures
        [HttpPost]
        public Pressure CreatePressure(Pressure pressure)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Pressures.Add(pressure);
            _context.SaveChanges();

            return pressure;
        }

        // PUT /api/pressures/1
        [HttpPut]
        public void UpdatePressure(int id, Pressure pressure)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var pressureInDb = _context.Pressures.SingleOrDefault(c => c.Id == id);
            if (pressureInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            pressureInDb.userId = pressure.userId;
            pressureInDb.Systolic = pressure.Systolic;
            pressureInDb.Diastolic = pressure.Diastolic;
            pressureInDb.Date = pressure.Date;

            _context.SaveChanges();
        }

        //DELETE /api/pressures/1
        [HttpDelete]
        public void DeletePressure(int id)
        {
            var pressureInDb = _context.Pressures.SingleOrDefault(c => c.Id == id);
            if (pressureInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Pressures.Remove(pressureInDb);
            _context.SaveChanges();
        }
    }
}
