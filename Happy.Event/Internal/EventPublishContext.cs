using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Event.Internal
{
    internal sealed class EventPublishContext : IEventPublishContext
    {
        private readonly List<EventInterceptorAttribute> _interceptors;
        private readonly Action _delagateWapper;
        private int _currentInterceptorIndex = -1;

        internal EventPublishContext(object @event,
                            IEnumerable<EventInterceptorAttribute> interceptors,
                            Action delagateWapper)
        {
            Check.MustNotNull("@event", "@event");
            Check.MustNotNull("interceptors", "interceptors");
            Check.MustNotNull("delagateWapper", "delagateWapper");

            this.Event = @event;
            _interceptors = interceptors.OrderBy(x => x.Order).ToList();
            _delagateWapper = delagateWapper;
        }

        public object Event { get; private set; }

        public void Next()
        {
            _currentInterceptorIndex++;
            if (_currentInterceptorIndex < _interceptors.Count)
            {
                _interceptors[_currentInterceptorIndex].Intercept(this);
            }
            else
            {
                _delagateWapper();
            }
        }
    }
}
