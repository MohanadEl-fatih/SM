using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Events
{
    public interface IEventDispatcher
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}
