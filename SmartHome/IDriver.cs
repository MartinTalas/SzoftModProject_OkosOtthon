using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public interface IDriver
    {
        public int sendCommand(Subscriber sub, bool boiler, bool ac);
    }
}
