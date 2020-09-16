using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Domain.Core.Extensions
{
    public interface ISMBuilder
    {
        IServiceCollection Services { get; }
    }
}
