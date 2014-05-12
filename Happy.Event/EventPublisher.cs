using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Event.Internal;

namespace Happy.Event
{
    /// <summary>
    /// 获取或访问<see cref="IEventPublisher"/>实例的唯一入口。
    /// </summary>
    public static class EventPublisher
    {
        private static readonly DefaultEventPublisher _DefaultEventPublisher
            = new DefaultEventPublisher();

        private static EventPublisherProvider _CurrentProvider = GetDefaultEventPublisher;

        /// <summary>
        /// 当前应用程序正在使用的事件发布者。
        /// </summary>
        public static IEventPublisher Current
        {
            get { return _CurrentProvider(); }
        }

        /// <summary>
        /// 设置当前应用程序正在使用的事件发布者提供者。
        /// </summary>
        public static void SetProvider(EventPublisherProvider provider)
        {
            Check.MustNotNull(provider, "provider");

            _CurrentProvider = provider;
        }

        private static IEventPublisher GetDefaultEventPublisher()
        {
            return _DefaultEventPublisher;
        }
    }
}
