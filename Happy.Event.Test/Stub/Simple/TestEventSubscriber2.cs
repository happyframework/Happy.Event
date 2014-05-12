using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Event.Test.Stub.Simple
{
    public sealed class TestEventSubscriber2 : IEventSubscriber<TestEvent>
    {
        public void Handle(TestEvent @event)
        {
            @event.Output += ("TestEventSubscriber2");
        }
    }
}
