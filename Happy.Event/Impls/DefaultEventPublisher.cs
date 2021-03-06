﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.Practices.ServiceLocation;

using Happy.Utils.Reflection;

namespace Happy.Event.Impls
{
    internal sealed class DefaultEventPublisher : IEventPublisher
    {
        public void Publish<TEvent>(TEvent @event)
        {
            Check.MustNotNull(@event, "@event");

            var context = this.CreateEventPublishContext(@event);

            context.Proceed();
        }

        private EventPublishContext CreateEventPublishContext<TEvent>(
                                                                TEvent @event)
        {
            var subscribers = ServiceLocator.Current
                                      .GetAllInstances<IEventSubscriber<TEvent>>();
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
                    this.ScheduleSubscriber<TEvent>(@event, subscriber);
                }
            });
        }

        private void ScheduleSubscriber<TEvent>(TEvent @event,
                                            IEventSubscriber<TEvent> subscriber)
        {
            var interceptors = subscriber.GetType()
                                    .GetAttributes<EventInterceptorAttribute>();
            var context = new EventPublishContext(@event, interceptors, () =>
            {
                subscriber.Handle(@event);
            });
            context.Proceed();
        }
    }
}
