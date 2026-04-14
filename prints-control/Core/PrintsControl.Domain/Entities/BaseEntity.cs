using System;
using System.ComponentModel.DataAnnotations;

namespace PrintsControl.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }
        public DateTimeOffset CreatedAt { get; protected set; }
        public DateTimeOffset UpdatedAt { get; protected set; }
        public DateTimeOffset? DeletedAt { get; protected set; }
        
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = CreatedAt;
            DeletedAt = null;
        }

        protected BaseEntity(Guid id, DateTimeOffset createdAt, DateTimeOffset updatedAt, DateTimeOffset deletedAt)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }

        public void MarkAsUpdated() => UpdatedAt = DateTimeOffset.UtcNow;
        public void MarkAsDeleted() => DeletedAt = DateTimeOffset.UtcNow;

    }
}