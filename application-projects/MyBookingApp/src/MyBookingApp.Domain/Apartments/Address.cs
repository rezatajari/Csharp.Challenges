namespace MyBookingApp.Domain.Apartments;

public sealed record Address
{
    public string Country { get; }
    public string State { get; }
    public string City { get; }
    public string Street { get; }
    public string PostalCode { get; }

    private Address(string country, string state, string city, string street, string postalCode)
    {
        Country = country;
        State = state;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    public static Address Create(
        string country,
        string state,
        string city,
        string street,
        string postalCode)
    {
        return new Address(
            Required(country, nameof(country)),
            Required(state, nameof(state)),
            Required(city, nameof(city)),
            Required(street, nameof(street)),
            Required(postalCode, nameof(postalCode)));
    }

    private static string Required(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value is required.", parameterName);
        }

        return value.Trim();
    }
}