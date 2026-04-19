using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBaseRepository<BaseAccount>, BaseRepository<BaseAccount>>();
builder.Services.AddScoped<IFinanceService, FinanceService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();