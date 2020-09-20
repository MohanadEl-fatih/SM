using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Bus.Dispatcher
{
    public interface IBusDispatcher
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
