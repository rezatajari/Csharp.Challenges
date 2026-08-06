namespace MyBookingApp.Domain.Shared;

public sealed record Money
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    private Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, Currency currency)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Money cannot be negative.");
        }

        ArgumentNullException.ThrowIfNull(currency);
        return new Money(amount, currency);
    }

    public static Money operator +(Money first, Money second)
    {
        ArgumentNullException.ThrowIfNull(first);
        ArgumentNullException.ThrowIfNull(second);

        if (first.Currency != second.Currency)
        {
            throw new InvalidOperationException("Money values must use the same currency.");
        }

        return new Money(first.Amount + second.Amount, first.Currency);
    }

    public static Money operator *(Money money, int multiplier)
    {
        ArgumentNullException.ThrowIfNull(money);

        if (multiplier < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(multiplier), "Multiplier cannot be negative.");
        }

        return new Money(money.Amount * multiplier, money.Currency);
    }
}