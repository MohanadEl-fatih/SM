using SM.Core.Events;
using SM.Core.Queries.Dispatcher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Dispatcher
{

    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly IEventDispatcher _eventDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher,
                          IQueryDispatcher queryDispatcher,
                          IEventDispatcher eventDispatcher)
        {
            this._commandDispatcher = commandDispatcher;
            this._queryDispatcher = queryDispatcher;
            this._eventDispatcher = eventDispatcher;
        }

        public async Task Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            await _commandDispatcher.Send<TCommand>(command);
        }

        public async Task Publish<T>(T @event) where T : class, IEvent
        {
            //we need a way to know if event is in mem or bus event
            await _eventDispatcher.Publish<T>(@event);
        }

        public async Task<TResult> Query<TResult>(IQuery<TResult> query)
        {
            return await _queryDispatcher.Query<TResult>(query);
        }

        public async Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>
        {
            return await _queryDispatcher.Query<TQuery, TResult>(query);
        }


    }
}
