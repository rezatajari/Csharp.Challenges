using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Dtos
{
    public record CategorySummary(string CategoryName, decimal TotalAmount,int TransactionCount);
}
