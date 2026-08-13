namespace MyBookingApp.Domain.Users;


public sealed class Permission
{
    public static readonly Permission UserRead = new(1, "user:read");
    private Permission(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; init; }
    public string Name { get; init; }
}