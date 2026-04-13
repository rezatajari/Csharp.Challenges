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

        [HttpPost]
        public IActionResult CreateHabit([FromBody] CreateHabitRequest habitReq)
        {
            Habit newHabit = Habit.Create(habitReq.Name);
            return Created("", newHabit);
        }
    }
}
