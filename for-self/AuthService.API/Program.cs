using Microsoft.AspNetCore.Components.Infrastructure;
using System.Net.Sockets;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<List<UserResponse>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/signup", (RegisterRequest request,List<UserResponse> users) => {
    try
    {
        var response = UserResponse.Create(request.Email, request.Username);

        users.Add(response);

        return TypedResults.Created($"/users/{response.Id}", response);
    }
    catch (Exception ex)
    {
        return TypedResults.BadRequest(ex.Message);
    }
});

app.Run();


public record RegisterRequest(string Email, string Password,string Username);
public record UserResponse
{
    private UserResponse(string email, string username)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email must be provided.", nameof(email));

        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username must be provided.", nameof(username));

        Id = Guid.NewGuid();
        Email = email;
        Username = username;
    }

    public Guid Id { get; init; }
    public string Email { get; init; }
    public string Username { get; init; }

    public static UserResponse Create(string email, string username)
        => new UserResponse( email, username);
}
