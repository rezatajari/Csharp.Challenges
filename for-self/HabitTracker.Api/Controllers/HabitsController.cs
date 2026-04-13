using HabitTracker.Api.DTOs;
using HabitTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{
    [Route("api/habits")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly HabitService _habitService;
        public HabitsController(HabitService habitService)
        {
            _habitService = habitService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateHabit([FromBody] CreateHabitDto newHabit)
        {
           var result= await _habitService.Create(newHabit);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        
    }
}
