using MyBookingApp.Domain.Abstractions;
using MyBookingApp.Domain.Shared;

namespace MyBookingApp.Domain.Apartments;

public sealed class Apartment : BaseEntity
{


    public Apartment(
        Name name,
        Description description,
        Address address,
        Money price,
        Money cleaningFee,
        List<Amenity> amenities)
        : base()
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        Amenities = amenities;
    }

    private Apartment() { }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public List<Amenity> Amenities { get; private set; } = new();
    public DateTime? LastBookedOnUtc { get; internal set; }
}