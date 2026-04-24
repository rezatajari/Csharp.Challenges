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

        public async Task< ReturnResponse<CreateHabitResponseDto>> Create(CreateHabitDto createHabitDto)
        {

            var habit = Habit.Create(createHabitDto.Name);
            var result= await _habitRepo.Add(habit);

            CreateHabitResponseDto response = new CreateHabitResponseDto(result.Id, result.Name);
            return ReturnResponse<CreateHabitResponseDto>.Success(response);
        }
    }
}
