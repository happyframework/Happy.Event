using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Event.Test.Stub.Simple
{
    [TestEventInterceptor1Attibute(1)]
    [TestEventInterceptor2Attibute(2)]
    public sealed class TestEvent
    {
        public TestEvent()
        {
            this.Output = "";
        }

        public string Output { get; set; }
    }
}
