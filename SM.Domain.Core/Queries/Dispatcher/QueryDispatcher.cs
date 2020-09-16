using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Queries.Dispatcher
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IResolver _resolver;

        public QueryDispatcher(IResolver resolver)
        {
            this._resolver = resolver;
        }

        public async Task<TResult> Query<TResult>(IQuery<TResult> query)
        {
            //Need to be test iam not sure if it's work
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _resolver.Resolve(handlerType);
            return await handler.Handle(query);
        }

        public async Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>
        {
            var handler = _resolver.Resolve<IQueryHandler<TQuery, TResult>>();
            return await handler.Handle(query);
        }
    }
}
