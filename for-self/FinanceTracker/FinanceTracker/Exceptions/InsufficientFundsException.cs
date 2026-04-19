using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Exceptions
{
    public class InsufficientFundsException:Exception
    {
        public InsufficientFundsException(string message) : base(message){ }
    }
}
