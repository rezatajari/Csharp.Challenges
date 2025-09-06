bool validInput = false;
string input;
int result;
bool stopInput = false;
string allInput = "";

while (!stopInput)
{
    do
    {
        validInput = false;
        Console.WriteLine("Please enter a number between 0 and 10 OR enter Q to exit program:");
        input = Console.ReadLine();

        if (int.TryParse(input, out result))
        {
            if (result >= 0 && result <= 10)  // بازه درست 0 تا 10
            {
                validInput = true;
                allInput += input + ",";
            }
            else
            {
                Console.WriteLine("Invalid Input. Number must be between 0 and 10.");
            }
        }
        else if (input.ToUpper() == "Q")
        {
            validInput = true;
            stopInput = true;
        }
        else
        {
            Console.WriteLine("Invalid Input. Please enter a number or 'Q'.");
        }

    } while (!validInput);
}

if (!string.IsNullOrEmpty(allInput))
{
    string[] numbers = allInput.Split(',', StringSplitOptions.RemoveEmptyEntries);

    Console.WriteLine("\nFrequency Distribution:");
    for (int i = 0; i <= 10; i++)
    {
        Console.Write(i + ": ");
        for (int c = 0; c < numbers.Length; c++)
        {
            if (Convert.ToInt32(numbers[c]) == i)
                Console.Write("*");
        }
        Console.WriteLine();
    }
}
else
{
    Console.WriteLine("No numbers were entered.");
}

Console.WriteLine("\nProgram finished.");
