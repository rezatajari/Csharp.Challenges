using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public record CategorySummary(string CategoryName, decimal TotalAmount,int TransactionCount);
}
