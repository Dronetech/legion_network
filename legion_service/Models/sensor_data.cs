using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace legion_service.Models
{


    public enum sensor_type
	{
        temperature,
        humidity,
	    voltage     
	}

    public class user_network
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Guid userGuid { get; set; }
        public virtual ICollection<sensor_data> sensors { get; set; }
    }

    public class sensor_data
    {
        public int Id { get; set; }
        public string sensor_name { get; set; }
        public string sensor_alias { get; set; }
        public float temperature { get; set; }
        public int humidity { get; set; }
        public int voltage {get; set; }
        public DateTime timestamp { get; set; }
        public string userGuid { get; set; }
        [Required]
        public int user_networkId { get; set; }
       
    }

    public class generic_sensor_data
    {
         public int Id { get; set; }
         public string userGuid { get; set; }
         public string sensor_name { get; set; }
         public float sensor_value { get; set; }
         public DateTime timestamp { get; set; }

    }
}