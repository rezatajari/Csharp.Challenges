
int max=0;
int min=10000;
int counter = 0;
int randomNumber;

Random rand = new Random();

for (int i = 0; i < 1000; i++)
{
    randomNumber=rand.Next(0,100001);
    if (randomNumber % 2 != 0)
    {
        counter++;
        max = (randomNumber > max) ? randomNumber : max;
        min = (randomNumber < min) ? randomNumber : min;
    }
}

Console.WriteLine("Max Number: {0}\n" +
                  "Min Number: {1}\n" +
                  "Total Number Generated: {2} Final Result",max,min, counter);


