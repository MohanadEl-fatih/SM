using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Core
{
    public interface IQuery
    {
    }

    public interface IQuery<TResult> : IQuery
    {
    }
}
