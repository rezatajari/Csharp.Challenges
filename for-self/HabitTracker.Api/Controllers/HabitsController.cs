using HabitTracker.Api.DTOs;
using HabitTracker.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {

        private static readonly List<Habit> _habits=new List<Habit>();
        [HttpPost]
        public IActionResult CreateHabit([FromBody] CreateHabitRequest habitReq)
        {
            Habit newHabit = Habit.Create(habitReq.Name);
            _habits.Add(newHabit);
            HabitDto habitDto = new HabitDto(newHabit.Id, newHabit.Name);
            return Created($"/api/habits/{habitDto.id}", habitDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetHabit([FromQuery] Guid id)
        {
            return Ok(_habits.FirstOrDefault(h => h.Id == id));
        }


        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_habits.ToList());
        }
    }
}
