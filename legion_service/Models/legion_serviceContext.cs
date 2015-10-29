using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace legion_service.Models
{
    public class legion_serviceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public legion_serviceContext() : base("name=legion_serviceContext")
        {

        }

        public virtual System.Data.Entity.DbSet<legion_service.Models.sensor_data> sensor_data { get; set; }
        public virtual System.Data.Entity.DbSet<legion_service.Models.user_network> user_network { get; set; }
    
    }
}
