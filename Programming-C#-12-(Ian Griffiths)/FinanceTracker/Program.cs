using FinanceTracker.Entities;

var myAccount = Account.Create("Savings", Money.Create(100, Currency.USD), TypeName.Bank);
var targetAccount = Account.Create("Checking", Money.Create(0, Currency.USD), TypeName.Bank);

try
{
    myAccount.TransferTo(targetAccount, Money.Create(500, Currency.USD), DateTime.Now, description: "Transfer to other my account");
    Console.WriteLine("Success!");
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine("User Error: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("System Error: " + ex.Message);
}
finally
{
    Console.WriteLine("Session closed. Current Balance: " + myAccount.Balance.Amount);
}