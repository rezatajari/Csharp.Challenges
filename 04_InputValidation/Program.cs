int counterGood=0;
int counterBad = 0;
string input="";

do
{
    Console.WriteLine("Please enter a number  0 - 99, or type Q to quit");
    input = Console.ReadLine();
    if (!input.ToUpper().Equals("Q"))
    {
        int number = 0;
        if (int.TryParse(input, out number))
        {
            if (number is >= 0 and <= 99)
                counterGood++;
            else
                counterBad--;
        }
        else
            counterBad--;
    }

}
while (!input.ToUpper().Equals("Q"));

Console.WriteLine("Valid numbers entered: {0}",counterGood);
Console.WriteLine("Invalid numbers entered: {0}", counterBad);