using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Api.DTOs
{
    public record CreateHabitDto
    {
        [Required]
        public string Name { get; init; }
    }
}
