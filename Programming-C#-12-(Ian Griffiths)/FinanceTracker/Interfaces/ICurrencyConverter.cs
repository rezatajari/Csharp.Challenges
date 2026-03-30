using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Interfaces
{
    public interface ICurrencyConverter
    {
        decimal GetRate(Currency from, Currency to);
    }
}
