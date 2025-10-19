using BirdWatcher;

int[] birdsThisWeek = { 2, 5, 0, 7, 4, 1, 3 };

BirdCount birdCount = new BirdCount(birdsThisWeek);

Console.WriteLine($"Today: {birdCount.Today()}");

birdCount.IncrementTodaysCount();
Console.WriteLine($"After increment, Today: {birdCount.Today()}");

Console.WriteLine($"Has day without birds? {birdCount.HasDayWithoutBirds()}"); 

Console.WriteLine($"Count for first 4 days: {birdCount.CountForFirstDays(4)}"); 

Console.WriteLine($"Busy days: {birdCount.BusyDays()}");

int[] lastWeek = BirdCount.LastWeek();
Console.WriteLine("Last week counts: " + string.Join(", ", lastWeek));
