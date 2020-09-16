using Microsoft.Extensions.DependencyInjection;
using SM.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Core.Command
{
    public static class Extensions
    {
        public static ISMBuilder AddCommandHandler(this ISMBuilder builder)
        {
            builder.Services.Scan(scan =>
                  scan.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                      .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                      .AsImplementedInterfaces()
                      .WithTransientLifetime());

            return builder;
        }

        public static ISMBuilder AddCommandDispatcher(this ISMBuilder builder)
        {
            builder.Services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            return builder;
        }
    }
}
