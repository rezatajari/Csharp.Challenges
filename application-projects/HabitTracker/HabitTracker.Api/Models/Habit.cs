namespace HabitTracker.Api.Models
{
    public class Habit
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Habit(string name)
        {
            Name = name;
        }

        public static Habit Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return new Habit(name);
        }
    }
}
