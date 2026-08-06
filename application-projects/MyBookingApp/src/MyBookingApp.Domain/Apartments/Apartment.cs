using MyBookingApp.Domain.Abstractions;
using MyBookingApp.Domain.Shared;

namespace MyBookingApp.Domain.Apartments;

public sealed class Apartment : BaseEntity
{
    private readonly List<Amenity> _amenities = [];

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public IReadOnlyCollection<Amenity> Amenities => _amenities.AsReadOnly();
    public DateTime? LastBookedOnUtc { get; private set; }

    private Apartment() { }

    public static Apartment Create(
        string name,
        string description,
        Address address,
        Money price,
        Money cleaningFee,
        IEnumerable<Amenity>? amenities = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Apartment name is required.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Apartment description is required.", nameof(description));
        }

        ArgumentNullException.ThrowIfNull(address);
        ArgumentNullException.ThrowIfNull(price);
        ArgumentNullException.ThrowIfNull(cleaningFee);

        if (price.Currency != cleaningFee.Currency)
        {
            throw new ArgumentException("Price and cleaning fee must use the same currency.", nameof(cleaningFee));
        }

        Apartment apartment = new()
        {
            Name = name.Trim(),
            Description = description.Trim(),
            Address = address,
            Price = price,
            CleaningFee = cleaningFee
        };

        if (amenities is not null)
        {
            apartment._amenities.AddRange(amenities.Distinct());
        }

        return apartment;
    }
}