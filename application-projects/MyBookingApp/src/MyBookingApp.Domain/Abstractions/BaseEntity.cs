namespace MyBookingApp.Domain.Abstractions;

public abstract class BaseEntity
{
    public  Guid Id { get; protected set; }
    protected DateTime CreatedAt { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

}