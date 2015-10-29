using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using legion_service.Models;
using System.Web.Http.Cors;

namespace legion_service.Controllers
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class sensor_dataController : ApiController
    {      
        private ISensorRepository db;

        public sensor_dataController(ISensorRepository repository)
        {           
            this.db = repository;
        }

        [Route("api/sensor_data/lastData/{userID}")]
        public sensor_data GetLastSensorData(string userID)
        {
          
            return db.getLastSensorData(userID);
        }

        [Route("api/sensor_data/SensorNameArray/{userID}")]
        public List<string> GetSensors(string userID)
        {
            return db.getSensorNames("");
        }
          
        //GET: api/sensor_data
        public List<sensor_data> Getsensor_data(string userID)        
        {
            //IQueryable<sensor_data> l = db.sensor_data.OrderByDescending(x => x.Id).Take(200);
            return db.getAllSensorData("");
        }

        //// GET: api/sensor_data/5
        //[ResponseType(typeof(sensor_data))]
        //public async Task<IHttpActionResult> Getsensor_data(int id)
        //{
        //    sensor_data sensor_data = await db.sensor_data.FindAsync(id);
        //    if (sensor_data == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(sensor_data);
        //}


        // POST: api/sensor_data
        [ResponseType(typeof(sensor_data))]
        public async Task<IHttpActionResult> Postsensor_data(sensor_data sensor_data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await db.AddSensorData(sensor_data);
            return CreatedAtRoute("DefaultApi", new { id = sensor_data.Id }, sensor_data);
        }

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
           {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool sensor_dataExists(int id)
        //{
        //    return db.sensor_data.Count(e => e.Id == id) > 0;
        //}


    }
}