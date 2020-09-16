using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Domain.Core.Mapping
{
    public interface IObjectFactory
    {
        dynamic CreateConcreteObject(object obj);
    }
}
