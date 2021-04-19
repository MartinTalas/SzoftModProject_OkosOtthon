using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeProject
{
    interface IDriver
    {
        public int sendCommand(Subscriber subs, bool boiler, bool ac);
    }
}
