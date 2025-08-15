using System;

namespace PrintsControl.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset CreatedAt { get; protected set; }
        public DateTimeOffset UpdatedAt { get; protected set; }
        public DateTimeOffset? DeletedAt { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkAsUpdated()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkAsDeleted()
        {
            DeletedAt = DateTimeOffset.UtcNow;
        }
    }
}