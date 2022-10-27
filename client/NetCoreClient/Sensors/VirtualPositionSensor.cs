using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualPositionSensor : IPositionSensorInterface, ISensorInterface
    {
        private readonly Random Random;

        public VirtualPositionSensor()
        {
            Random = new Random();
        }

        public double Longitude()
        {
            return new Longitude(Random.NextDouble()*Random.Next(100)).Value;
        }

        public double Latitude()
        {
            return new Latitude(Random.NextDouble()*Random.Next(100)).Value;
        }

        public string ToJson()
        {
            Object[] Position = {new Longitude(Random.NextDouble()*Random.Next(100)), new Latitude(Random.NextDouble()*Random.Next(100))};
            return JsonSerializer.Serialize(Position);
        }
    }
}