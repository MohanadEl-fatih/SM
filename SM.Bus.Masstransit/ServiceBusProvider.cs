using MassTransit;
using SM.Core;
using SM.Core.Bus;
using System;
using System.Threading.Tasks;

namespace SM.Bus.Masstransit
{
    public class ServiceBusProvider : IBusProvider, ICommandDispatcher
    {

        private readonly IBusControl _busControl;

        public ServiceBusProvider(IBusControl busControl)
        {
            this._busControl = busControl;
        }

        public async Task Publish<TMessage>(TMessage message) where TMessage : IEvent
        {
            await _busControl.Publish<IBusProvider>(message);
        }

        public void Subscribe<TEvent>() where TEvent : class, IEvent
        {
            throw new NotImplementedException();
        }

        public Task Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            throw new NotImplementedException();
        }
    }
}
