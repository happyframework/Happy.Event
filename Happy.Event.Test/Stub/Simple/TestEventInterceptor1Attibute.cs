using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Event.Test.Stub.Simple
{
    public sealed class TestEventInterceptor1Attibute : EventInterceptorAttribute
    {
        public TestEventInterceptor1Attibute(int order)
            : base(order)
        {
        }

        public override void Intercept(IEventPublishContext context)
        {
            (context.Event as TestEvent).Output += ("Before:TestEventInterceptor1Attibute");
            context.Next();
            (context.Event as TestEvent).Output += ("After:TestEventInterceptor1Attibute");
        }
    }
}
