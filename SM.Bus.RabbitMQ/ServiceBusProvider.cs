using SM.Core;
using System;
using System.Threading.Tasks;

namespace SM.Bus.RabbitMQ
{
    public class ServiceBusProvider : IBusProvider, ICommandDispatcher
    {
        public Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TEvent>() where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public Task Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            throw new NotImplementedException();
        }
    }
}
