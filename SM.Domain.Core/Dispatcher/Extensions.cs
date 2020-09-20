using Microsoft.Extensions.DependencyInjection;
using SM.Core.Bus.Dispatcher;
using SM.Core.Command;
using SM.Core.Events;
using SM.Core.Queries;
using SM.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Core.Dispatcher
{
    public static class Extensions
    {
        public static ISMBuilder AddDispatcherHandler(this ISMBuilder builder)
        {
            builder.AddEventHandler();
            builder.AddQueryHandler();
            builder.AddCommandHandler();
          
            return builder;
        }

        public static ISMBuilder AddDispatcher(this ISMBuilder builder)
        {
            builder.AddEventDispatcher();
            builder.AddBusDispatcher();
            builder.AddCommandDispatcher();
            builder.AddQueryDispatcher();
            return builder;
        }


        public static ISMBuilder AddDispatcherHandler(this ISMBuilder builder,Type type)
        {
            builder.Services.Scan(scan =>
                        scan.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                            .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime());

            return builder;
        }
    }
}
