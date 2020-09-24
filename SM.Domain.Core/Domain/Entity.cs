using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Domain.Core.Domain
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; protected set; }

        protected Entity()
        { 
        }

        protected Entity(T id)
        { 
            Id = id;
        }
        public override string ToString()
        {
            return $"[{GetType().Name}] Id = {Id}";
        }
    }
}