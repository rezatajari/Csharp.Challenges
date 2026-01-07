using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyFoundation
{
    public readonly struct Transaction
    {
        public Transaction(Money amount, TransactionType type)
        {
            Amount = (amount.Amount==0) ? throw new ArgumentException("Transaction amount cannot be zero.", nameof(amount)) 
                : amount;
            if (Enum.TryParse<TransactionType>(type.ToString(),out var result))
            {
                Type = result;
            }
            else
            {
                throw new ArgumentException("Invalid transaction type.", nameof(type));
            }
            Timestamp = DateTime.UtcNow;
        }
        public Money Amount { get; }
        public TransactionType Type { get; }
        public DateTime  Timestamp{ get; }

    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}
