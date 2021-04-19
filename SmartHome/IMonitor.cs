using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeProject
{
    interface IMonitor
    {
        public Session getSession(string homeId);
    }
}
