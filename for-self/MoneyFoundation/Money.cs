namespace MoneyFoundation
{
    public readonly struct Money(decimal amount, Currency currency)
    {
        public decimal Amount { get;} = amount;
        public Currency Currency { get;  } = currency;

        public static Money operator +(Money left, Money right)
        => (left.Currency != right.Currency)
            ? throw new InvalidOperationException(
                $"Mismatched Currency: Cannot add {left.Currency.Name} and {right.Currency.Name}")
            : new Money(left.Amount + right.Amount, left.Currency);
    }
}
