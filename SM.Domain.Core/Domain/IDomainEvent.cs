using System;

namespace SM.Domain.Core.Domain
{
    public interface IDomainEvent
    {
        Guid Id { get; set; }
        Guid AggregateRootId { get; set; }
        Guid CommandId { get; set; }

    }
}