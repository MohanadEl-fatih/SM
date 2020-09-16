using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Core
{
    public interface IResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
        object Resolve(Type type);
        IEnumerable<object> ResolveAll(Type type);
    }
}
