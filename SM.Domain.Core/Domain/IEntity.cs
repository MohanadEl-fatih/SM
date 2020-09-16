using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Domain.Core.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
