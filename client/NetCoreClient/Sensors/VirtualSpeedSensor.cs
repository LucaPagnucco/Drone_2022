using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace NetCoreClient.Sensors
{
    class VirtualSpeedSensor : ISpeedSensorInterface, ISensorInterface
    {
        public string ToJson()
        {
            return "{\"speed\": " + GetSpeed() + "}";
        }

        public int GetSpeed()
        {
            var random = new Random();
            return random.Next(100);
        }

        public string GetSlug()
        {
            return "speed";
        }
    }
}
