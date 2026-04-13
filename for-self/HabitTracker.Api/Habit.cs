namespace HabitTracker.Api
{
    public class Habit
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Habit() { 
         Id = Guid.NewGuid();
        }
        public static Habit Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var habit = new Habit();
            habit.Name = name;
            return habit;
        }
    }
}
