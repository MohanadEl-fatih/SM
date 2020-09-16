using SM.Core;
using System;
using System.Threading.Tasks;

namespace SM.Bus.RabbitMQ
{
    public class ServiceBusProvider : IEventListener, ICommandDispatcher
    {
        public Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new NotImplementedException();
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
