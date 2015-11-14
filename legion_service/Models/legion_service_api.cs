using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace legion_service.Models
{
    public class legion_service_api : ISensorRepository
    {
      
        private readonly legion_serviceContext db;
        public legion_service_api(legion_serviceContext _db)
        {
            this.db = _db;
        }

        public sensor_data getLastSensorData(string userID)
        {
            
            var _out = db.sensor_data.Where(u => u.userGuid == userID).OrderByDescending(x => x.Id).FirstOrDefault();
          

            return _out;
        }

        public List<sensor_data> getLastSensorData(string userID, int top)
        {
            return db.sensor_data.Where(u => u.userGuid == userID).OrderByDescending(x => x.Id).Take(top).ToList();
        }


        public List<sensor_data> getAllSensorData(string userID)
        {
           return db.sensor_data.Where(x => x.userGuid == userID).ToList();
        }

        public async System.Threading.Tasks.Task<int> AddSensorData(sensor_data sensor_data)
        {
            sensor_data.timestamp = DateTime.Now;

            db.sensor_data.Add(sensor_data);
            return await db.SaveChangesAsync();

        }


        public void Dispose()
        {
            db.Dispose();
        }


        public List<string> getSensorNames(string userID)
        {
            var sensors = (from c in db.sensor_data
                           where c.userGuid == userID
                           select c.sensor_name).Distinct();
            return sensors.ToList();
        }


        public sensor_data GetLastSensorData(string userid, string sensor_name)
        {
            return db.sensor_data.Where(x => x.sensor_name == sensor_name && x.userGuid == userid).OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}