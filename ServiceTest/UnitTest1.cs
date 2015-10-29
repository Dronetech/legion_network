using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using legion_service.Models;
using Moq;
using System.Data.Entity;
using legion_service.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace legion_service.Tests.Models
{


    [TestClass]
    public class ServiceAPI
    {
      
        [TestMethod]
        public void getSensorData()
        {

            var controller = generateSensorDataSet();
            var sensors = controller.getAllSensorData("teste.teste.teste");

            Assert.AreEqual(4, sensors.Count);                        

        }

        [TestMethod]
        public void getLastSensorDataWithTop()
        {

            var controller = generateSensorDataSet();
            var sensors = controller.getLastSensorData("teste.teste.teste", 2);

            Assert.AreEqual(2, sensors.Count);
            Assert.AreEqual(5, sensors[0].Id);

        }

        [TestMethod]
        public void getLastSensorData()
        {

            var controller = generateSensorDataSet();
            var sensors = controller.getLastSensorData("teste.teste.teste");

            Assert.AreEqual(5, sensors.Id);
           

        }

        private legion_service_api generateSensorDataSet()
        {
            Random rnd = new Random();

            IQueryable<sensor_data> data = new List<sensor_data>
            {
                new sensor_data { Id = 1, userGuid = "teste.teste.teste", sensor_name = "sensor1", timestamp = DateTime.Now.AddMilliseconds(rnd.Next(1000, 10000))},
                new sensor_data { Id = 3, userGuid = "teste.teste.teste", sensor_name = "sensor2", timestamp = DateTime.Now.AddMilliseconds(rnd.Next(1000, 10000))},
                new sensor_data { Id = 4, userGuid = "teste.teste.teste", sensor_name = "sensor2", timestamp = DateTime.Now.AddMilliseconds(rnd.Next(1000, 10000))},
                new sensor_data { Id = 5, userGuid = "teste.teste.teste", sensor_name = "sensor3", timestamp = DateTime.Now.AddMilliseconds(rnd.Next(1000, 10000))},
                new sensor_data { Id = 6, userGuid = "teste.teste.teste2", sensor_name = "sensor2", timestamp = DateTime.Now.AddMilliseconds(rnd.Next(1000, 10000))},
                new sensor_data { Id = 7, userGuid = "teste.teste.teste2", sensor_name = "sensor2", timestamp = DateTime.Now.AddMilliseconds(rnd.Next(1000, 10000))},
                new sensor_data { Id = 2, userGuid = "teste.teste.teste2", sensor_name = "sensor1", timestamp = DateTime.Now.AddMilliseconds(rnd.Next(1000, 10000))}

            }.AsQueryable();
            var mockset = new Mock<DbSet<sensor_data>>();
            mockset.As<IQueryable<sensor_data>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<sensor_data>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<sensor_data>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<sensor_data>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<legion_serviceContext>();
            mockContext.Setup(s => s.sensor_data).Returns(mockset.Object);

           return new legion_service_api(mockContext.Object);

        }
      
    }
}
