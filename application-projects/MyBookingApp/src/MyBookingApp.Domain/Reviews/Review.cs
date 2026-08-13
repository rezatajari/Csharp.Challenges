using MyBookingApp.Domain.Abstractions;

namespace MyBookingApp.Domain.Reviews;


public sealed class Review:BaseEntity
{
    public Guid ApartmentId { get; set; }
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public int Rating { get;private set; }
    public string Comment { get; private set; }

}