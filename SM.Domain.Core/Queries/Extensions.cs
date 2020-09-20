using Microsoft.Extensions.DependencyInjection;
using SM.Core.Queries.Dispatcher;
using SM.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Core.Queries
{
    public static class Extensions
    {
        public static ISMBuilder AddQueryHandler(this ISMBuilder builder)
        {
            builder.Services.Scan(scan =>
                  scan.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                      .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                      .AsImplementedInterfaces()
                      .WithTransientLifetime());

            return builder;
        }

        public static ISMBuilder AddQueryDispatcher(this ISMBuilder builder)
        {
            builder.Services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            return builder;
        }
    }
}
