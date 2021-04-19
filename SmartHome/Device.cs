using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    class Device
    {
        public string devicename { get;}
        public string commandTurnOff { get; }
        public string commandTurnOn { get; }
        
        public Device(string devicename ,string commandTurnOff, string commandTurnOn)
        {
            this.devicename = devicename;
            this.commandTurnOff = commandTurnOff;
            this.commandTurnOn = commandTurnOn;
        }
    }
}
