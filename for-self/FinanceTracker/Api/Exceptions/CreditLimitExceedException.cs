using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Exceptions
{
    public class CreditLimitExceedException:Exception
    {
        public decimal AttemptedAmount { get; }
        public decimal CurrentLimit { get; }

        public CreditLimitExceedException(string message,decimal attempted,decimal limit)
            : base(message)
        {
            AttemptedAmount= attempted;
            CurrentLimit= limit;
        }
    }
}
