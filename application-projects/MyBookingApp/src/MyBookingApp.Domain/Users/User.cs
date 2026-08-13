using MyBookingApp.Domain.Abstractions;

namespace MyBookingApp.Domain.Users;



public sealed class User : BaseEntity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public string Email { get; private set; }
}