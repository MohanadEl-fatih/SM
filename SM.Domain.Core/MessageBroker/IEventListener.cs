using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core
{
    public interface IEventListener
    {
        void Subscribe<TEvent>() where TEvent : IEvent;
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
