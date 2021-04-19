using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeProject
{
    interface IDriver
    {
        int sendCommand(Subscriber subs, bool boiler, bool ac);
    }
}
