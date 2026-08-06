namespace MyBookingApp.Domain.Shared;

public sealed record Currency
{
    public string Code { get; }

    private Currency(string code)
    {
        Code = code;
    }

    public static Currency Create(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Currency code is required.", nameof(code));
        }

        return new Currency(code.Trim().ToUpperInvariant());
    }
}