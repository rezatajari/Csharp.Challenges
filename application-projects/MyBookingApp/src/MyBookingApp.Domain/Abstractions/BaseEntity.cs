namespace MyBookingApp.Domain.Abstractions;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents=new();

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedOnUtc = DateTime.UtcNow;
    }
    public Guid Id { get; protected set; }
    public DateTime CreatedOnUtc { get; private set; }
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}