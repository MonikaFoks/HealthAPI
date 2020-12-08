using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HealthAPI.Controllers.Api
{
    public class PulsesController : ApiController
    {
        private Context _context;

        public PulsesController()
        {
            _context = new Context();
        }
        // GET /api/pulses
        public IEnumerable<Pulse> GetPulses()
        {
            return _context.Pulses.ToList();
        }

        //GET /api/pulses/1
        [HttpGet]
        public Pulse GetPulse(int id)
        {
            var pulse = _context.Pulses.SingleOrDefault(c => c.Id == id);

            if (pulse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return pulse;
        }

        //POST /api/pulses
        [HttpPost]
        public Pulse CreatePulse(Pulse pulse)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Pulses.Add(pulse);
            _context.SaveChanges();

            return pulse;
        }

        // PUT /api/pulses/1
        [HttpPut]
        public void UpdatePulse(int id, Pulse pulse)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var pulseInDb = _context.Pulses.SingleOrDefault(c => c.Id == id);
            if (pulseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            pulseInDb.userId = pulse.userId;
            pulseInDb.Bpm = pulse.Bpm;
            pulseInDb.Date = pulse.Date;

            _context.SaveChanges();
        }

        //DELETE /api/pulses/1
        [HttpDelete]
        public void DeletePulse(int id)
        {
            var pulseInDb = _context.Pulses.SingleOrDefault(c => c.Id == id);
            if (pulseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Pulses.Remove(pulseInDb);
            _context.SaveChanges();
        }
    }
}