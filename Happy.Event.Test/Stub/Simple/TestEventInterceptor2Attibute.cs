using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Event.Test.Stub.Simple
{
    public sealed class TestEventInterceptor2Attibute : EventInterceptorAttribute
    {
        public TestEventInterceptor2Attibute(int order)
            : base(order)
        {
        }

        public override void Intercept(IEventPublishContext context)
        {
            (context.Event as TestEvent).Output += ("Before:TestEventInterceptor2Attibute");
            context.Next();
            (context.Event as TestEvent).Output += ("After:TestEventInterceptor2Attibute");
        }
    }
}
