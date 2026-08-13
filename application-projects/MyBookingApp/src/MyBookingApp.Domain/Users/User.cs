using MyBookingApp.Domain.Abstractions;

namespace MyBookingApp.Domain.Users;



public class User : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
}