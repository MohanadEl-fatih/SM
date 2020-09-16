using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SM.Domain.Core.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
        int Version { get; }
        ReadOnlyCollection<IDomainEvent> Events { get; }
    }
}
