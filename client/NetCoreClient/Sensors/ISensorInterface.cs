using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreClient.Sensors
{
    interface ISensorInterface
    {
        string ToJson();

        string GetSlug();
    }
}
