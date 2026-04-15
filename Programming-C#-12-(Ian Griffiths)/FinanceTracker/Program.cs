using FinanceTracker.Data;
using FinanceTracker.Entities;
using FinanceTracker.Interfaces;
using FinanceTracker.Services;
using FinanceTracker.ValueObjects;
using Microsoft.EntityFrameworkCore;



var accountRepo = new JsonRepository<IAccount>("accounts.json");
var service = new FinanceService(accountRepo, new Repository<Transaction>());


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