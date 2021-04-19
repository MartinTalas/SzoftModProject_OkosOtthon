using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SmartHomeProject
{
    class Driver:IDriver
    {
        private string onCommand;
        private string offCommand;

        Driver(string onCommand, string offCommand)
        {
            this.onCommand = onCommand;
            this.offCommand = offCommand;
        }

        public int sendCommand(Subscriber subs, bool boiler, bool ac)
        {
            if(boiler)
            {

            }
            else
            {

            }
            if (ac)
            {

            }
            else
            {

            }

            return 404;
        }

        public string turnOn()
        {
            return onCommand;
        }

        public string turnOff()
        {
            return offCommand;
        }

    }
}
