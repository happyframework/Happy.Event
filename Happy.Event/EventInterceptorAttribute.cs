using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Event
{
    /// <summary>
    /// 事件拦截器。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public abstract class EventInterceptorAttribute : Attribute
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="order">指示拦截器在管道中的位置</param>
        protected EventInterceptorAttribute(int order)
        {
            this.Order = order;
        }

        /// <summary>
        /// 拦截正在发布的事件。
        /// </summary>
        public abstract void Intercept(IEventPublishContext context);

        /// <summary>
        /// 拦截器在管道中的位置。
        /// </summary>
        public int Order { get; protected set; }
    }
}
