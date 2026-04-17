using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
