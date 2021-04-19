using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    class Controller
    {
        private Loader loader = new Loader();
        private Subscribers subscribers = new Subscribers();

        public Controller()
        {
            this.subscribers = this.loader.loadSubscribers();
        }
    }
}
