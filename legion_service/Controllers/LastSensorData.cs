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
        private legion_serviceContext db = new legion_serviceContext();

       [Route("api/LastSensorData/{sensor_name}")]
       public sensor_data GetLastSensorData(string sensor_name)
        {
            return db.sensor_data.Where(x => x.sensor_name == sensor_name).OrderByDescending(x => x.Id).FirstOrDefault();
        }

    }
}
