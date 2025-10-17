Console.OutputEncoding = System.Text.Encoding.UTF8;
const int trackLength = 10;
Random random = new Random();

Tortoise tortoise = new Tortoise(trackLength);
Hare hare = new Hare(trackLength);

while (tortoise.Position < trackLength && hare.Position < trackLength)
{
    // Each animal decides its move based on a random number
    tortoise.Move(random.Next(1, 101));
    hare.Move(random.Next(1, 101));

    tortoise.Display();
    hare.Display();

    Thread.Sleep(1000);

    // Clear console only if race is still ongoing
    if (tortoise.Position < trackLength && hare.Position < trackLength)
        Console.Clear();
}

// Declare the winner
Console.WriteLine();
if (hare.Position > tortoise.Position)
    Console.WriteLine(hare.Name + " Won!");
else if (tortoise.Position > hare.Position)
    Console.WriteLine(tortoise.Name + " Won!");
else
    Console.WriteLine("It's a Tie!");
