using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
