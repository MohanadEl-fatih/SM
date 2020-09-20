using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Dispatcher
{
    public interface IDispatcher
    {
        Task Send<TCommand>(TCommand command) where TCommand : class, ICommand;

        Task<TResult> Query<TResult>(IQuery<TResult> query);

        Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>;

        Task Publish<T>(T @event) where T : class, IEvent;
    }
}
