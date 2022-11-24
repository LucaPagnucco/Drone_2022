using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreClient.Sensors
{
    interface IPositionSensorInterface
    {
        float GetLongitude();

        float GetLatitude();
    }
}