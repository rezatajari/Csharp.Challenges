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

    var response = new UserResponse(Guid.NewGuid(), request.Email, request.Username);

    users.Add(response);

    return TypedResults.Created($"/users/{response.Id}", response);
});

app.Run();


public record RegisterRequest(string Email,string Username,string Password);
public record UserResponse(Guid Id,string Email,string Username);
