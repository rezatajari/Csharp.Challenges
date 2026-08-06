using MyBookingApp.Domain.Abstractions;
using MyBookingApp.Domain.Shared;

namespace MyBookingApp.Domain.Bookings;


public sealed class Booking : BaseEntity
{
    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpcharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }
    private Booking() { }

    public static Booking Create(
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money amenitiesUpcharge)
    {
        if (apartmentId == Guid.Empty)
        {
            throw new ArgumentException("Apartment ID is required.", nameof(apartmentId));
        }

        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User ID is required.", nameof(userId));
        }

        ArgumentNullException.ThrowIfNull(duration);
        ArgumentNullException.ThrowIfNull(priceForPeriod);
        ArgumentNullException.ThrowIfNull(cleaningFee);
        ArgumentNullException.ThrowIfNull(amenitiesUpcharge);

        return new Booking
        {
            ApartmentId = apartmentId,
            UserId = userId,
            Duration = duration,
            PriceForPeriod = priceForPeriod,
            CleaningFee = cleaningFee,
            AmenitiesUpcharge = amenitiesUpcharge,
            TotalPrice = priceForPeriod + cleaningFee + amenitiesUpcharge,
            Status = BookingStatus.Pending
        };
    }
}
