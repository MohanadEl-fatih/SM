using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Bus.Dispatcher
{
    public class BusDispatcher : IBusDispatcher
    {
        private readonly IBusProvider _busProvider;

        public BusDispatcher(IBusProvider busProvider)
        {
            this._busProvider = busProvider;
        }
        public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            await _busProvider.Publish(@event);
        }
    }
}
