internal class Tortoise
{
    public string Name { get; set; } = "🐢";

    // Current position on the track
    public int Position { get; private set; } = 0;

    // Track length to limit movement
    private int trackLength;

    public Tortoise(int trackLength)
    {
        this.trackLength = trackLength;
    }

    // Decide move based on a random number
    public void Move(int randomNumber)
    {
        int step = randomNumber switch
        {
            > 0 and < 50 => 3,   // Fast Plod
            > 49 and < 80 => 1,  // Slow Plod
            _ => -6               // Slip
        };

        // Update position
        Position += step;

        // Ensure position stays within track boundaries
        Position = Math.Max(0, Position);
        Position = Math.Min(trackLength, Position);
    }

    public void Display()
    {
        for (int i = 0; i < Position; i++)
            Console.Write("-");
        Console.WriteLine(Name);

    }
}