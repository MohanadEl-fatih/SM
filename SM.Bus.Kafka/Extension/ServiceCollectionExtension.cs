using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SM.Bus.Kafka.Configuration;
using SM.Core.Bus;
using SM.Core.Events;
using SM.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Bus.Kafka.Extension
{
    public static class ServiceCollectionExtension
    {
        public static ISMBuilder AddKafka(this ISMBuilder builder, Action<KafkaOptions> configureOptions)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            //builder.Services.Configure(configureOptions);
            //var sp = builder.Services.BuildServiceProvider();
            //var options = sp.GetService<IOptions<KafkaOptions>>().Value;

            builder.Services.AddTransient<IBusProvider, ServiceBusProvider>();
            builder.Services.AddTransient<IEventDispatcher, EventDispatcher>();

            return builder;
        }
    }
}
