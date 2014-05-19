using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Event
{
    /// <summary>
    /// 事件发布上下文接口，代表了一次事件爱你的发布过程。
    /// </summary>
    public interface IEventPublishContext
    {
        /// <summary>
        /// 正在发生的事件。
        /// </summary>
        object Event { get; }

        /// <summary>
        /// 执行下一个<see cref="EventInterceptorAttribute"/>，如果已经是最后一个，就会
        /// 执行所有的<see cref="IEventSubscriber{TEvent}"/>。
        /// </summary>
        void Proceed();
    }
}
