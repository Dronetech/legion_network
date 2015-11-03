using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace legion_service.Models
{
    public interface ISensorRepository
    {
        /*DbSet<sensor_data> sensor_data { get; set; }
        DbSet<user_network> user_network { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        void Dispose();*/

        sensor_data getLastSensorData(string userID);
        List<sensor_data> getAllSensorData(string userID);
        List<sensor_data> getLastSensorData(string userID, int top);
        List<string> getSensorNames(string userID);
        Task<int> AddSensorData(sensor_data sensor_data);
        sensor_data GetLastSensorData(string userid, string sensor_name);
        void Dispose();

    }
}
