using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationReporter.External
{
    /// <summary>
    /// An interface to control position reporting with consumers
    /// </summary>
    interface IPositionReport
    {
        bool sendPosition(String latitude, String longitude);
    }
}
