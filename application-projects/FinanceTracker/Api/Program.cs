using Api;
using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy =>
        {
            policy
                .WithOrigins("https://localhost:7090")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseSqlServer(connectionString));

Log.Logger = new LoggerConfiguration()
    .WriteTo.MSSqlServer(
    connectionString: connectionString,
    sinkOptions: new MSSqlServerSinkOptions
    {
        TableName = "Logs",
        AutoCreateSqlTable = true
    })
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddScoped<IFinanceRepository, FinanceRepository>();
builder.Services.AddScoped<IFinanceService, FinanceService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddProblemDetails();
var app = builder.Build();

app.UseExceptionHandler();
app.UseCors("AllowBlazor");
app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();