﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Tests
{
    [TestClass()]
    public class MonitorTests
    {
        [TestMethod()]
        public void getSessionTest()
        {
            Monitor m = new Monitor();
            Session s = m.getSession("");
            Assert.IsNull(s);
            //Assert.IsNull(s);
        }
    }
}