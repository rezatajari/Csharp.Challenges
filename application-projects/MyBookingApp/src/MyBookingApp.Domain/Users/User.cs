using System.Runtime.InteropServices;
using MyBookingApp.Domain.Abstractions;

namespace MyBookingApp.Domain.Users;



public sealed class User : BaseEntity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public IReadOnlyCollection

    private User() { }

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        return new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
    }
}