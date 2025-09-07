int[] positiveNumbers;
int[] negativeNumbers;
int N = 0;


Console.Write("Please enter how many numbers are to be calculated: ");
N = Convert.ToInt32(Console.ReadLine());

positiveNumbers = new int[N];
negativeNumbers = new int[N];

//populate arrays with zeroes
PopulateWithZeroes();
PopulateWithRandomNumbers();
OutputPositive();
OutputNegative();
OutputSum();

void OutputSum()
{
    Console.Write("Position Sum of numbers: ");
    for (int i = 0; i < N; i++)
    {
        if (positiveNumbers[i] != 0 || negativeNumbers[i] != 0)
            Console.Write(positiveNumbers[i] + negativeNumbers[i] + ", ");
    }

    Console.WriteLine("");
}

void OutputNegative()
{
    Console.Write("Negative Numbers ({0} of them): ", N);
    foreach (var value in negativeNumbers)
        Console.Write(value + ", ");

    Console.WriteLine("");
}

void OutputPositive()
{
    Console.Write("Positive Numbers ({0} of them): ", N);
    foreach (var value in positiveNumbers)
        Console.Write(value + ", ");

    Console.WriteLine("");
}

void PopulateWithRandomNumbers()
{
    Random rand = new Random();
    int randomNumber = 0;
    bool positiveNumber = false;

    for (int i = 0; i < N; i++)
    {
        bool randomNotZero = false;
        while (!randomNotZero) //if random number is zero, get another number
        {
            randomNumber = rand.Next(-100, 101);
            if (randomNumber != 0)
                randomNotZero = true;
        }

        positiveNumber = (randomNumber > 0) ? true : false;
        AddNumberToArray(randomNumber, positiveNumber);
    }
}

void AddNumberToArray(int numberToAdd, bool positiveNumber)
{
    for (int i = 0; i < N; i++)
    {
        if (positiveNumber)
        {
            if (positiveNumbers[i] == 0)
            {
                positiveNumbers[i] = numberToAdd;
                return;
            }
        }
        else
        {
            if (negativeNumbers[i] == 0)
            {
                negativeNumbers[i] = numberToAdd;
                return;
            }
        }
    }
}

void PopulateWithZeroes()
{
    for (int i = 0; i < N; i++)
    {
        positiveNumbers[i] = 0;
        negativeNumbers[i] = 0;
    }
}