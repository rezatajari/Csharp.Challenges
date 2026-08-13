using System.Runtime.InteropServices;
using MyBookingApp.Domain.Abstractions;
using MyBookingApp.Domain.Users.Events;

namespace MyBookingApp.Domain.Users;



public sealed class User : BaseEntity
{
    private readonly List<Role> _roles=new();
    private User (FirstName firstName,LastName lastName,Email email)
    :base()
    {
        FirstName=firstName;
        LastName=lastName;
        Email=email;
    }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public string IdentityId { get;private set; }=string.Empty; 
    public IReadOnlyCollection<Role> Roles=> _roles.ToList();

    private User() { }

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
       User user=new User(firstName,lastName,email);
       user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
       user._roles.Add(Role.Registered);

       return user;
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId=identityId;
    }
}