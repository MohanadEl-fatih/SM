using SM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core
{
    public interface IEventHandler<in TEvent> where TEvent : class, IEvent
    {
        Task Handle(TEvent @event);
    }
}
