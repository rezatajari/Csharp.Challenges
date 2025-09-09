int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
Random rand = new Random();

int counter= 0;
do
{
    counter++;
    Console.WriteLine(counter);
    SwitchCells();
}
while (!IsMagicSquare());

DisplayBoard();
Console.WriteLine($"It took {counter} tries.");

void DisplayBoard()
{
    for (var i = 0; i < 3; i++)
    {
        for(var c = 0; c < 3; c++)
        {
            Console.Write(numbers[i,c] + " ");
        }
        Console.WriteLine();
    }
}

bool IsMagicSquare()
{
    var tempSum = numbers[0, 0] + numbers[0, 1] + numbers[0, 2];
    // Compare rows; start from row 1 because tempsSum already holds the sum for row 0
    for (var i = 1; i < 3; i++)
    {
        if (numbers[i, 0] + numbers[i, 1] + numbers[i, 2] != tempSum)
            return false;
    }

    // Compare columns
    for (var i = 0; i < 3; i++)
    {
        if (numbers[0, i] + numbers[1, i] + numbers[2, i] != tempSum)
            return false;
    }

    return numbers[0, 0] + numbers[1, 1] + numbers[2, 2] == tempSum &&
           numbers[0, 2] + numbers[1, 1] + numbers[2, 0] == tempSum;
}

void SwitchCells()
{
    int[] number1 = new int[2];
    int[] number2 = new int[2];

    number1[0] = rand.Next(0, 3);
    number1[1] = rand.Next(0, 3);
    number2[0] = rand.Next(0, 3);
    number2[1] = rand.Next(0, 3);

    int temp = numbers[number1[0], number1[1]];
    numbers[number1[0], number1[1]] = numbers[number2[0], number2[1]];
    numbers[number2[0], number2[1]] = temp;


}