using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get;protected set; }
        public DateTime CreatedAt { get;protected set; } = DateTime.Now;
        public bool IsDeleted { get; protected set; }
    }
}
