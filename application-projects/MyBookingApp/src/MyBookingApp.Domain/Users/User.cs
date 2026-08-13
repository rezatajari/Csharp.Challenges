using System.Runtime.InteropServices;
using MyBookingApp.Domain.Abstractions;

namespace MyBookingApp.Domain.Users;



public sealed class User : BaseEntity
{
    private readonly List<Role> _roles=new();
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public string IdentityId { get;private set; }=string.Empty; 
    public IReadOnlyCollection<Role> Roles=> _roles.ToList();

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

    public void SetIdentityId(string identityId)
    {
        IdentityId=identityId;
    }
}