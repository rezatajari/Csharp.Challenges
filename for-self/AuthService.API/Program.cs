var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


app.MapPost("/signup", (RegisterRequest request) => {

    var response = new UserResponse(Guid.NewGuid(), request.Email, request.Username);

    return TypedResults.Created($"/users/{response.Id}", response);
});
public record RegisterRequest(string Email,string Username,string Password);
public record UserResponse(Guid Id,string Email,string Username);

