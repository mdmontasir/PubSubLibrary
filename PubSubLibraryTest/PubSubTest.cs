using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PubSubLibrary;

namespace PubSubLibraryTest
{
    [TestClass]
    public class PubSubTest
    {
        [TestMethod]
        public void SubscribeTest()
        {            
            var hub = new PubSub();
            int callCount = 0;

            var sender1 = new object();
            var sender2 = new object();

            hub.Subscribe(sender1, new Action<string>(a => callCount++));
            hub.Subscribe(sender2, new Action<string>(a => callCount++));
           
            hub.Publish(null, default(string));
            
            Assert.AreEqual(2, callCount);
        }

        [TestMethod]
        public void UnSubscribeTest()
        {           
            var hub = new PubSub();
            int callCount = 0;

            var sender1 = new object();
            var sender2 = new object();

            hub.Subscribe(sender1, new Action<string>(a => callCount++));
            hub.Subscribe(sender2, new Action<string>(a => callCount++));

            hub.Unsubscribe(sender1);
                       
            hub.Publish(null, default(string));
                      
            Assert.AreEqual(1, callCount);
        }
    }
}
