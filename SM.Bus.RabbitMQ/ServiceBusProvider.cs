using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RawRabbit;
using SM.Bus.RabbitMQ.RawRabbit.Configuration;
using SM.Core;
using SM.Core.Bus;
using SM.Core.Events;
using System;
using System.Threading.Tasks;

namespace SM.Bus.RabbitMQ
{
    public class ServiceBusProvider : IBusProvider, ICommandDispatcher
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IBusClient _busClient;
        private readonly RabbitMQOptions _options;


        public ServiceBusProvider(IEventDispatcher eventDispatcher, IBusClient busClient, IOptions<RabbitMQOptions> options)
        {
            this._eventDispatcher = eventDispatcher;
            this._busClient = busClient;
            this._options = options.Value;
        }

        public void Subscribe<TEvent>() where TEvent : class, IEvent
        {
            this._busClient.SubscribeAsync<TEvent>(
                async (msg) =>
                {
                    await _eventDispatcher.Publish(msg);
                },
                cfg => cfg.UseSubscribeConfiguration(
                    c => c
                    .OnDeclaredExchange(e => e
                        .WithName(_options.Exchange.Name)
                        .WithType(_options.Exchange.Type)//not well thougt
                        .WithArgument("key", typeof(TEvent).Name.ToLower()))
                    .FromDeclaredQueue(q => q.WithName($"{_options.Queue.Name}-" + typeof(TEvent).Name)))
                );
        }

        public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event), "Event can not be null.");
            }

            await _busClient.PublishAsync(
                @event,
                cfg => cfg.UsePublishConfiguration(
                    c => c
                    .OnDeclaredExchange(e => e
                    .WithName(_options.Exchange.Name)
                    .WithType(_options.Exchange.Type)//not well thougt
                    .WithArgument("key", typeof(TEvent).Name.ToLower()))

                )
            );
        }


        public Task Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            throw new NotImplementedException();
        }
    }
}