using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Bus
{
    public interface IBusProvider
    {
        void Subscribe<TEvent>() where TEvent : class, IEvent;
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
