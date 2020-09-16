using SM.Bus.Masstransit.Configuration;
using SM.Domain.Core.Extensions;
using System;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;

namespace SM.Bus.Masstransit.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //public static ISMBuilder AddMasstransit(this ISMBuilder builder, Action<MasstransitOptions> configureOptions)
        //{
        //    if (builder == null)
        //    {

        //    }

        //    if (configureOptions == null)
        //    {

        //    }

        //    builder.Services.Configure(configureOptions);
        //    var sp = builder.Services.BuildServiceProvider();
        //    var options = sp.GetService<IOptions<MasstransitOptions>>().Value;

        //    builder.Services.AddMassTransit(x =>
        //    {
        //        x.UsingRabbitMq();
        //    });

        //}
    }
}
