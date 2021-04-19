using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace SmartHome
{
    class Controller
    {
        private Loader loader = new Loader();
        //private Driver driver = new Driver();
        private Monitor monitor = new Monitor();
        private Subscribers subscribers = new Subscribers();

        public Controller()
        {
            this.subscribers = this.loader.loadSubscribers();
        }
    }
}
