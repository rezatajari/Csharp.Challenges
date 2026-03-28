using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime CreateAt{ get; set; }
        public Category Category{ get; set; }
        public Account Account{ get; set; }
        public string? Description { get; set; }
    }
}
