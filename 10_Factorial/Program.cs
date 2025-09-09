using System.Numerics;

Console.WriteLine("Enter a number to calculate factorial (Q to quit):");

while (true)
{
    string input = Console.ReadLine();

    if (input.Trim().ToUpper() == "Q") break;

    if (!int.TryParse(input, out int number) || number < 0)
    {
        Console.WriteLine("Please enter a valid non-negative integer.");
        continue;
    }

    BigInteger result = 1;
    for (int i = 1; i <= number; i++)
        result *= i;

    Console.WriteLine($"Factorial of {number} = {result}");
}