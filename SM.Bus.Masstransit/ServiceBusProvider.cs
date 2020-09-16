using MassTransit;
using SM.Core;
using System;
using System.Threading.Tasks;

namespace SM.Bus.Masstransit
{
    public class ServiceBusProvider : IEventListener, ICommandDispatcher
    {

        private readonly IBusControl _busControl;

        public ServiceBusProvider(IBusControl busControl)
        {
            this._busControl = busControl;
        }

        public async Task Publish<TMessage>(TMessage message) where TMessage : IEvent
        {
            await _busControl.Publish<IEventListener>(message);
        }

        public void Subscribe<TEvent>() where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        Task ICommandDispatcher.Send<TCommand>(TCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
