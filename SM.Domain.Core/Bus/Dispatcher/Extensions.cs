using Microsoft.Extensions.DependencyInjection;
using SM.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Core.Bus.Dispatcher
{
    public static class Extensions
    {
        public static ISMBuilder AddBusDispatcher(this ISMBuilder builder)
        {
            builder.Services.AddSingleton<IBusDispatcher, BusDispatcher>();
            return builder;
        }
    }
}
