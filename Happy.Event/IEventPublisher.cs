using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Factory;

namespace Happy.Event
{
    /// <summary>
    /// 事件发布者接口。
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// 发布<paramref name="@event"/>。
        /// </summary>
        void Publish<TEvent>(TEvent @event);

        /// <summary>
        /// 设置<paramref name="factory"/>。
        /// </summary>
        void SetFactory(IFactory factory);
    }
}
