using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common
{
    public abstract class Entity<TKey>
    {
        public virtual TKey Id { get; protected set; } = default!;

        public virtual bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(
                Id,
                default);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TKey> other)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (IsTransient() || other.IsTransient())
            {
                return false;
            }

            return GetType() == other.GetType()
                   && EqualityComparer<TKey>.Default.Equals(
                       Id,
                       other.Id);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(
                GetType(),
                Id);
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Id}]";
        }
    }
}
