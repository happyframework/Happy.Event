using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Event
{
    /// <summary>
    /// 事件订阅者接口。
    /// </summary>
    public interface IEventSubscriber<TEvent>
    {
        /// <summary>
        /// 处理<paramref name="@event"/>。
        /// </summary>
        void Handle(TEvent @event);
    }
}
