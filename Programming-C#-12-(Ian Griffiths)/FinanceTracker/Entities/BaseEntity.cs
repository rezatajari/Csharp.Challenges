using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get;protected set; }
        public DateTime CreatedAt { get;protected set; } = DateTime.UtcNow;
        public bool IsDeleted { get; protected set; } = false;

        public void Delete()
            => IsDeleted = true;
    }
}
