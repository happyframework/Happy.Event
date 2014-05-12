using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Happy.Utils.Reflection;
using Happy.Factory;

namespace Happy.Event.Internal
{
    internal sealed class DefaultEventPublisher : IEventPublisher
    {
        private IFactory _factory = new DefaultFactory();

        public void Publish<TEvent>(TEvent @event)
        {
            Check.MustNotNull(@event, "@event");

            var context = this.CreateEventPublishContext(@event);

            context.Next();
        }

        public void SetFactory(Factory.IFactory factory)
        {
            Check.MustNotNull(factory, "factory");

            _factory = factory;
        }

        private EventPublishContext CreateEventPublishContext<TEvent>(
                                                                TEvent @event)
        {
            var subscribers = _factory.CreateInstances<IEventSubscriber<TEvent>>();

            var interceptors = @event.GetType()
                                     .GetAttributes<EventInterceptorAttribute>();

            return new EventPublishContext(@event, interceptors, () =>
            {
                if (subscribers == null)
                {
                    return;
                }

                foreach (var subscriber in subscribers)
                {
                    subscriber.Handle(@event);
                }
            });
        }
    }
}
