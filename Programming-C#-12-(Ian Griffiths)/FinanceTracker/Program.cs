using FinanceTracker.Data;
using FinanceTracker.Data.Repositories;
using FinanceTracker.Entities;
using FinanceTracker.Interfaces;
using FinanceTracker.Services;
using FinanceTracker.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<FinanceDbContext>(options =>
        {
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<FinanceService>();
    })
    .Build();


using (IServiceScope scope = host.Services.CreateScope())
{
    var accountService = scope.ServiceProvider.GetRequiredService<FinanceService>();


    Console.WriteLine("=== Welcome to FinanceTracker ===");


    Console.Write("Enter Account Name: ");
    string name = Console.ReadLine() ?? "Unnamed Account";

    Console.Write("Enter Initial Balance: ");
    decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

    var initialMoney = Money.Create(amount, Currency.USD);
    var newAccount = SavingsAccount.Create(name, initialMoney, TypeName.Cash);

    service.OpenAccount(newAccount);

    Console.WriteLine($"\nSuccess! Account '{newAccount.Name}' created with ID: {newAccount.Id}");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();

}

await host.RunAsync();

