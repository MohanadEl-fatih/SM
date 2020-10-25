using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SM.Bus.Kafka.Configuration;
using SM.Core;
using SM.Core.Bus;
using SM.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Bus.Kafka
{
    public class ServiceBusProvider : IBusProvider, ICommandDispatcher
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly KafkaOptions _options;
        private readonly string[] _topics;

        public ServiceBusProvider(IEventDispatcher eventDispatcher, IOptions<KafkaOptions> options)
        {
            this._eventDispatcher = eventDispatcher;
            this._options = options.Value;
            this._topics = _options.Topics.Split(";");
        }

        public void Subscribe<TEvent>() where TEvent : class, IEvent
        {
            Subscribe(typeof(TEvent));
        }

        public void Subscribe(Type type)
        {
            using (var consumer = new ConsumerBuilder<string, string>(_options.Consumer).Build())
            {
                consumer.Subscribe(_topics);
                while (true)
                {
                    var message = consumer.Consume();

                    var @event = JsonConvert.DeserializeObject(message.Message.Value, type) as IEvent;
                    _eventDispatcher.Publish(@event);
                }
            }
        }

        public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            using (var p = new ProducerBuilder<string, string>(_options.Producer).Build())
            {
                await p.ProduceAsync(_options.Topic,
                    new Message<string, string>
                    {
                        Key = GetTypeName<TEvent>(),
                        Value = JsonConvert.SerializeObject(@event)
                    });
            }
        }

        public Task Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            throw new NotImplementedException();
        }

        private static string GetTypeName<TEvent>()
        {
            return GetTypeName(typeof(TEvent));

            string GetTypeName(Type type)
            {
                var name = type.FullName.ToLower().Replace("+", ".");

                if (type is IEvent)
                {
                    name += "_event";
                }

                return name;
            }
        }
    }
}
