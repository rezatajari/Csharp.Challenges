using Application.Interfaces;
using Application.UseCases.CreateTodo;
using Application.UseCases.DeleteTodo;
using Application.UseCases.GetTodo;
using Application.UseCases.UpdateTodo;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TodoAppDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<CreateTodoHandler>();
builder.Services.AddScoped<DeleteTodoHandler>();
builder.Services.AddScoped<GetTodoHandler>();
builder.Services.AddScoped<UpdateTodoHandler>();

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

app.MapGet("/ping", () => "pong");
