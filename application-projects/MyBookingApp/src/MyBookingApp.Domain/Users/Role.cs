namespace MyBookingApp.Domain.Users;


public sealed class Role
{
    
    public ICollection<User> users {get;init}=new List<User>();
}