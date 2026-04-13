using HabitTracker.Api.DTOs;
using HabitTracker.Api.Models;
using HabitTracker.Api.Repository;
using HabitTracker.Api.Shared;

namespace HabitTracker.Api.Services
{
    public class HabitService
    {
        private readonly HabitRepository _habitRepo;
        public HabitService(HabitRepository habitRepo)
        {
            _habitRepo = habitRepo;
        }

        public async ReturnResponse<CreateHabitResponseDto> Create(CreateHabitDto createHabitDto)
        {

            var habit = Habit.Create(createHabitDto.Name);
            _habitRepo.Add(habit);

        }
    }
}
