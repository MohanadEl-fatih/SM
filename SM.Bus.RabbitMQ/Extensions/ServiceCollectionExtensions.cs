using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RawRabbit.DependencyInjection.ServiceCollection;
using RawRabbit.Instantiation;
using SM.Bus.RabbitMQ.RawRabbit.Configuration;
using SM.Core;
using SM.Core.Bus;
using SM.Core.Events;
using SM.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Bus.RabbitMQ.RawRabbit.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ISMBuilder AddRabbitMQ(this ISMBuilder builder, Action<RabbitMQOptions> configureOptions)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            builder.Services.Configure(configureOptions);
            var sp = builder.Services.BuildServiceProvider();
            var options = sp.GetService<IOptions<RabbitMQOptions>>().Value;

            builder.Services.AddRawRabbit(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            builder.Services.AddTransient<IBusProvider, ServiceBusProvider>();
            builder.Services.AddSingleton<IEventDispatcher, EventDispatcher>();

            return builder;
        }
    }
}
