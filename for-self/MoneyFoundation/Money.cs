using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyFoundation
{
    public class Money(decimal amount, Currency currency)
    {
        public decimal Amount { get; set; } = amount;
        public Currency Currency { get; set; } = currency;
    }
}
