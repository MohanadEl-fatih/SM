using Microsoft.Extensions.DependencyInjection;
using SM.Bus.RabbitMQ.Configuration;
using SM.Core;
using SM.Core.Bus;
using SM.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Bus.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ISMBuilder AddMasstransit(this ISMBuilder builder, Action<RabbitMQOptions> configureOptions)
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

            builder.Services
                   .AddTransient<IBusProvider, ServiceBusProvider>();

            return builder;
        }
    }
}
