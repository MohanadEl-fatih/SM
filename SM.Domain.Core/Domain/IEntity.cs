using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Domain.Core.Domain
{
    /// <summary>
    /// used when entity has a one key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T>
    {
        T Id { get; }
    }

}
