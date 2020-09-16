using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Queries.Dispatcher
{
    public interface IQueryDispatcher
    {
        Task<TResult> Query<TResult>(IQuery<TResult> query);
        Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>;
    }
}
