using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IResolver _resolver;

        public EventDispatcher(IResolver resolver)
        {
            this._resolver = resolver;
        }

        public async Task Publish<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var handlers = _resolver.ResolveAll<IEventHandler<TEvent>>();

            foreach (var handler in handlers)
                await handler.Handle(@event);
        }
    }
}

