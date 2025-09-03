int beginningValue;
int endValue;

do
{
    Console.Write("Please enter beginning base value: ");
    beginningValue = Convert.ToInt32(Console.ReadLine());
    Console.Write("Please enter ending base value: ");
    endValue = Convert.ToInt32(Console.ReadLine());

    if (beginningValue < 2 || endValue > 8) 
        Console.WriteLine("Invalid Input");
}while(beginningValue<2||endValue>8);

Console.WriteLine("\n");

//headers
for (int i = beginningValue-1; i <= endValue; i++)
{
    if (i==beginningValue)
        Console.Write(string.Format("{0,6}","n"));
    else
        Console.Write(string.Format("{0,6}",i));
}

Console.WriteLine("\n");

for (int i = 1; i <= 25; i++) //rows
{
    Console.Write(string.Format("{0,6}",i));
    for (int b = beginningValue; b <= endValue; b++)// collums
    {
        string output = string.Format("{0,6}", i * b);
        Console.Write(output);
    }
    Console.WriteLine("");

}