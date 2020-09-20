using Microsoft.Extensions.DependencyInjection;
using SM.Core.Bus.Dispatcher;
using SM.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Core.Events
{
    public static class Extensions
    {
        public static ISMBuilder AddEventHandler(this ISMBuilder builder)
        {
            builder.Services.Scan(scan =>
                  scan.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                      .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                      .AsImplementedInterfaces()
                      .WithTransientLifetime());

            return builder;
        }

        public static ISMBuilder AddCommandDispatcher(this ISMBuilder builder)
        {
            builder.Services.AddSingleton<IEventDispatcher, EventDispatcher>();
            builder.Services.AddSingleton<IBusDispatcher, BusDispatcher>();
            return builder;
        }
    }
}
