using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace NetCoreClient.Sensors
{
    class VirtualPositionSensor : IPositionSensorInterface, ISensorInterface
    {
        public string ToJson()
        {
            return "{\"latitude\": " + GetLatitude() + ",\"longitude\": " + GetLongitude() + "}";
        }

        public float GetLatitude()
        {
            var random = new Random();
            return (float) random.Next(100);
        }

        public float GetLongitude()
        {
            var random = new Random();
            return (float)random.Next(100);
        }

        public string GetSlug()
        {
            return "latitude,longitude";
        }
    }
}