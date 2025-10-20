using Lucian_sLusciousLasagna;

var lasagna = new Lasagna();

Console.WriteLine("Testing Lasagna class...");
Console.WriteLine("-----------------------------");

Console.WriteLine($"Expected minutes in oven: {lasagna.ExpectedMinutesInOven()}");
Console.WriteLine($"Remaining minutes after 30: {lasagna.RemainingMinutesInOven(30)}");
Console.WriteLine($"Preparation time for 2 layers: {lasagna.PreparationTimeInMinutes(2)}");
Console.WriteLine($"Elapsed time (3 layers, 20 minutes in oven): {lasagna.ElapsedTimeInMinutes(3, 20)}");