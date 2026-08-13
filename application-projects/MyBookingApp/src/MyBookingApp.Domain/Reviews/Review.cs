using MyBookingApp.Domain.Abstractions;

namespace MyBookingApp.Domain.Reviews;


public sealed class Review:BaseEntity
{
    public Guid ApartmentId { get;private set; }
    public Guid BookingId { get;private set; }
    public Guid UserId { get;private set; }
    public int Rating { get;private set; }
    public string Comment { get; private set; }

}