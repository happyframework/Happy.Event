using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Event.Impls;

namespace Happy.Event
{
    /// <summary>
    /// 获取或访问<see cref="IEventPublisher"/>实例的唯一入口。
    /// </summary>
    public static class EventPublisher
    {
        private static readonly DefaultEventPublisher _Current
            = new DefaultEventPublisher();

        /// <summary>
        /// 当前应用程序正在使用的事件发布者。
        /// </summary>
        public static IEventPublisher Current
        {
            get { return _Current; }
        }
    }
}
