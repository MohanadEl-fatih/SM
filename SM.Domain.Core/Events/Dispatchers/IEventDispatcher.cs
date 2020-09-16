using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Events.Dispatchers
{
    public interface IEventDispatcher
    {
        Task Publish<T>(T @event) where T : class, IEvent;
    }
}
