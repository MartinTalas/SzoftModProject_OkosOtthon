using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHome;

namespace SmartHomeTests
{
    [TestClass()]
    class LoaderTests
    {
        [TestMethod()]
        public void loadSubscribersTest()
        {

            Subscribers loaded_subscribers = new Subscribers();
            Loader loader = new Loader();
            loaded_subscribers = loader.loadSubscribers();

            //hibátlan adatokkal
            Assert.IsTrue(loaded_subscribers.subscribers[0].homeId == "KD34AF24DS");

            //hibás adatokkal
            //Assert.IsFalse(loaded_subscribers.subscribers[0].homeId == "KD34AF24DS");


            //hibás filename-el
            //Assert.IsTrue(loaded_subscribers.subscribers == null);
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
