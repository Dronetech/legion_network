using legion_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace legion_service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LastSensorDataController : ApiController
    {
        private ISensorRepository db;
        
        public LastSensorDataController(ISensorRepository repository)
        {           
            this.db = repository;
        }

       [Route("api/LastSensorData/{userid}/{sensor_name}")]
       public sensor_data GetLastSensorData(string userid, string sensor_name)
        {
            return db.GetLastSensorData(userid, sensor_name);
        }

    }
}
