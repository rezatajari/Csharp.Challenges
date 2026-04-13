using Shortener;

var service = new ShortenerService();

while (true)
{
    Console.WriteLine("1: Create | 2: Resolve");
    var option = Console.ReadLine();

    if (option == "1")
    {
        Console.Write("Enter URL: ");
        var url = Console.ReadLine();

        var result = service.Create(url);

        Console.WriteLine($"Code: {result.Code}");
    }
    else if (option == "2")
    {
        Console.Write("Enter Code: ");
        var code = Console.ReadLine();

        var url = service.Resolve(code);

        Console.WriteLine(url ?? "Not found");
    }
}