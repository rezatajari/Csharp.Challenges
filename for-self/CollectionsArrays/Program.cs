decimal[] month = new decimal[12]
{
    1,2,3,4,5,6,7,8,9,10,11,12
};

decimal total = 0;
decimal min = month[0];
decimal max = month[0];

for (int i = 0; i < month.Length; i++)
{
    decimal value = month[i];

    total += value;

    if (value < min)
        min = value;

    if (value > max)
        max = value;
}

decimal average = total / month.Length;

Console.WriteLine(
    $"Total: {total}, Average: {average}, Min: {min}, Max: {max}");