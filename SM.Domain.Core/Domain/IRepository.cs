using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.Domain
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task SaveAsync(T aggregate);

        void Save(T aggregate);

        Task<T> GetByIdAsync(Guid id);

        T GetById(Guid id);
    }
}
