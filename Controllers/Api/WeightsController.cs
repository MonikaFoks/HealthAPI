using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HealthAPI.Controllers.Api
{
    public class WeightsController : ApiController
    {
        private Context _context;

        public WeightsController()
        {
            _context = new Context();
        }
        // GET /api/weights
        [HttpGet]
        public IEnumerable<Weight> GetWeights()
        {
            return _context.Weights.ToList();
        }

        //GET /api/weights/1
        public Weight GetWeight(int id)
        {
            var weight = _context.Weights.SingleOrDefault(c => c.Id == id);

            if (weight == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return weight;
        }

        //POST /api/weights
        [HttpPost]
        public Weight CreateWeight(Weight weight)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Weights.Add(weight);
            _context.SaveChanges();

            return weight;
        }

        // PUT /api/weights/1
        [HttpPut]
        public void UpdateWeight(int id, Weight weight)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var weightInDb = _context.Weights.SingleOrDefault(c => c.Id == id);
            if (weightInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            weightInDb.userId = weight.userId;
            weightInDb.Kgs = weight.Kgs;
            weightInDb.date = weight.date;

            _context.SaveChanges();
        }

        //DELETE /api/weights/1
        [HttpDelete]
        public void DeleteWeight(int id)
        {
            var weightInDb = _context.Weights.SingleOrDefault(c => c.Id == id);
            if (weightInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Weights.Remove(weightInDb);
            _context.SaveChanges();
        }
    }
}
