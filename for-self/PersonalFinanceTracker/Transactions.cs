using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinanceTracker
{
    public record Transactions (int Id,decimal Amount,string Description, DateTime Date);
}
