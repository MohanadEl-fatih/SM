using SM.Core.Bus;
using SM.Core.Bus.Dispatcher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IResolver _resolver;
        private readonly IBusDispatcher _busDispatcher;

        public EventDispatcher(IResolver resolver, IBusDispatcher busDispatcher)
        {
            this._resolver = resolver;
            this._busDispatcher = busDispatcher;
        }

        public async Task Publish<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var handlers = _resolver.ResolveAll<IEventHandler<TEvent>>();

            foreach (var handler in handlers)
                await handler.Handle(@event);

            if (@event is IBusMessage)
                await _busDispatcher.Publish(@event);
        }
    }
}

