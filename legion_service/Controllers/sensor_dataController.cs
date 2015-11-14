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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace legion_service.Controllers
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class sensor_dataController : ApiController
    {      
        private ISensorRepository db;
        private ApplicationUserManager _userManager;
        private ApplicationUser _ctx;

        public sensor_dataController(ISensorRepository repository)
        {           
            this.db = repository;            
           
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Route("api/sensor_data/lastData/")]
        [Authorize]
        public sensor_data GetLastSensorData()
        {
            
          return db.getLastSensorData(GetUserIDFromRequest());
        }

        private string GetUserIDFromRequest()
        {
            var user = UserManager.FindByName(User.Identity.Name);
            string userID = "";
            if (user != null)
            {
                userID = user.external_api_key;
            }
            return userID;
        }

        [Route("api/sensor_data/SensorNameArray/")]
        [Authorize]
        public List<string> GetSensors()
        {
            return db.getSensorNames(GetUserIDFromRequest());
        }
          
        //GET: api/sensor_data
        [Authorize]
        public List<sensor_data> Getsensor_data()        
        {
           
            //IQueryable<sensor_data> l = db.sensor_data.OrderByDescending(x => x.Id).Take(200);
            return db.getAllSensorData(GetUserIDFromRequest());
        }

     
        // POST: api/sensor_data
        [ResponseType(typeof(sensor_data))]
        [Authorize]
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