using MyBookingApp.Domain.Abstractions;

namespace MyBookingApp.Domain.Users.Events;



public sealed class UserCreatedDomainEvent(Guid UserId):IDomainEvent;