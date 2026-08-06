namespace MyBookingApp.Domain.Abstractions;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedOnUtc { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedOnUtc = DateTime.UtcNow;
    }
}