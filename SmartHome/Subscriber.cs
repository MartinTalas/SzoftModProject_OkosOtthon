﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Subscriber
    {
        public string subscriber
        {
            get;
            set;
        }
        public string homeId
        {
            get;
            set;
        }
        public string boilerType
        {
            get;
            set;
        }
        public string airConditionerType
        {
            get;
            set;
        }
        public List<Temperature>temperatures
        {
            get;
            set;
        }
    }
}
