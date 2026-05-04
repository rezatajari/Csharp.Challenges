using Api;
using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Services;
using Application.Shared;
using Application.Shared.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Authentication;
using Infrastructure.BackgroundJobs;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//  (Services Configuration)
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseSqlServer(connectionString));

//  Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.MSSqlServer(
        connectionString: connectionString,
        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true })
    .CreateLogger();

builder.Host.UseSerilog();

//  JWT
var jwtSettings = builder.Configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
            ClockSkew = TimeSpan.Zero
        };
    });

// DI
builder.Services.AddScoped<IFinanceRepository, FinanceRepository>();
builder.Services.AddScoped<IFinanceService, FinanceService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
builder.Services.AddHostedService<MonthlyReportWorker>();
builder.Services.AddHostedService<QueuedWorker>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddHealthChecks().AddSqlServer(connectionString!);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowBlazor", policy => {
        policy.WithOrigins("https://localhost:7090").AllowAnyHeader().AllowAnyMethod();
    });
});

// ---------------------------------------------------------
var app = builder.Build(); // Build Application
// ---------------------------------------------------------

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<FinanceDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}


app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowBlazor");
app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();