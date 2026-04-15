using FinanceTracker.Data;
using FinanceTracker.Data.Repositories;
using FinanceTracker.Dtos;
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
        services.AddScoped<IFinanceService, FinanceService>();
    })
    .Build();


using (IServiceScope scope = host.Services.CreateScope())
{
    var financeService = scope.ServiceProvider.GetRequiredService<FinanceService>();


    Console.WriteLine("=== Welcome to FinanceTracker ===");


    Console.Write("Enter Account Name: ");
    string name = Console.ReadLine() ?? "Unnamed Account";

    Console.Write("Enter Initial Balance: ");
    decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

    var initialMoney = Money.Create(amount, Currency.USD);
    var newAccount = SavingsAccount.Create(name, initialMoney, TypeName.Cash);

    var result =await financeService.OpenAccount(newAccount);

    if (!result.IsSuccess)
        Console.WriteLine(result.ErrorMessage);

    Console.WriteLine($"\nSuccess! Account '{newAccount.Name}' created with ID: {newAccount.Id}");
    // --- Start of Income Transaction Test ---
    Console.WriteLine("\n--- Testing Income Recording ---");

    // 1. Simulate the DTO (InputRecordTxDto)
    Console.Write("Enter Income Amount: ");
    decimal incomeAmount = decimal.Parse(Console.ReadLine() ?? "0");

    Console.Write("Enter Description: ");
    string description = Console.ReadLine() ?? "Monthly Salary";

    // 2. We need a Category. In a real app, you'd select this. 
    // For this test, we'll assume a 'Salary' category exists with Type = Income.
    // If you don't have one, you'd create it here via a CategoryRepository.
    var category = Category.Create("Salary", null, TransactionType.Income);

    var incomeDto = new InputRecordTxDto(
        accountId: newAccount.Id,
        amount: Money.Create(incomeAmount, Currency.USD),
        category: category,
        description: description
    );

    // 3. Execute the Service Method
    Console.WriteLine("Processing Income...");
    var incomeResult = await financeService.RecordIncome(incomeDto);

    if (incomeResult.IsSuccess)
    {
        Console.WriteLine("Income Recorded Successfully!");

        // 4. Verify the State Change (The "Skeptical" Check)
        // In a real E2E, we'd re-fetch the account from the DB to see if Balance updated
        Console.WriteLine($"Updated Balance for Account '{newAccount.Name}': {newAccount.Balance.Amount} {newAccount.Balance.Currency}");
    }
    else
    {
        Console.WriteLine($"Error: {incomeResult.ErrorMessage}");
    }

    Console.WriteLine("\n=== E2E Test Complete ===");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}

await host.RunAsync();

