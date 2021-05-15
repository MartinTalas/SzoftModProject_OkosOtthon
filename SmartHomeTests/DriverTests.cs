using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Tests
{
    [TestClass()]
    public class DriverTests
    {
        [TestMethod()]
        public void sendCommandTest()
        {
            Loader debug_loader = new Loader();
            Subscribers debug_subscribers = debug_loader.loadSubscribers();
            Driver d = new Driver();
            Assert.AreEqual(100, d.sendCommand(debug_subscribers.subscribers[0], true, false));
            Assert.AreEqual(100, d.sendCommand(debug_subscribers.subscribers[0], false, true));

            Assert.AreEqual(102, d.sendCommand(debug_subscribers.subscribers[2], true, false));
            Assert.AreEqual(102, d.sendCommand(debug_subscribers.subscribers[3], false, true));
        }
    }
}