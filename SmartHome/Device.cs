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
        
        public Device(string devicename ,string commandTurnOn, string commandTurnOff)
        {
            this.devicename = devicename;
            this.commandTurnOn = commandTurnOn;
            this.commandTurnOff = commandTurnOff;
            
        }
    }
}
