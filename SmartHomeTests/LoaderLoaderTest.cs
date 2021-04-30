using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Tests
{
    [TestClass()]
    public class LoaderLoaderTest
    {
        [TestMethod()]
        public void loadSubscribersTest()
        {
            Subscribers loaded_subscribers = new Subscribers();
            Loader loader = new Loader();
            loaded_subscribers = loader.loadSubscribers();
            Assert.IsTrue(loaded_subscribers.subscribers[0].homeId == "KD34AF24DS");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Subscribers loaded_subscribers = new Subscribers();
            Loader loader = new Loader();
            loaded_subscribers = loader.loadSubscribers();

            Assert.IsNotNull(loader.ToString());
        }
    }
}