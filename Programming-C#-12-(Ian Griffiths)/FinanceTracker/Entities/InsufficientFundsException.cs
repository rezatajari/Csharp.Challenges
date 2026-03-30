using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class InsufficientFundsException:Exception
    {
        public InsufficientFundsException(string message) : base(message){ }
    }
}
