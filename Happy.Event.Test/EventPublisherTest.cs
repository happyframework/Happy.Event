using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Microsoft.Practices.ServiceLocation;

using Happy.ServiceLocation;
using Happy.Event.Test.Stub.Simple;

namespace Happy.Event.Test
{
    [TestFixture]
    public class EventPublisherTest
    {
        [Test]
        public void Publish_Simple_Test()
        {
            ServiceLocator.SetLocatorProvider(() => new AppDomainServiceLocator());

            var testEvent = new TestEvent();

            EventPublisher.Current.Publish(testEvent);

            Assert.IsTrue(testEvent.Output.Contains(typeof(TestEventSubscriber1).Name));
            Assert.IsTrue(testEvent.Output.Contains(typeof(TestEventSubscriber2).Name));
            Assert.IsTrue(testEvent.Output.Contains(typeof(TestEventInterceptor1Attibute).Name));
            Assert.IsTrue(testEvent.Output.Contains(typeof(TestEventInterceptor2Attibute).Name));
            Assert.IsTrue(testEvent.Output.StartsWith("Before:" + typeof(TestEventInterceptor1Attibute).Name));
            Assert.IsTrue(testEvent.Output.Contains("After:" + typeof(TestEventInterceptor1Attibute).Name));
        }
    }
}
