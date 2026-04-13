using HabitTracker.Api.DTOs;
using HabitTracker.Api.Services;
using HabitTracker.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async IActionResult CreateHabit([FromBody] CreateHabitDto newHabit)
        {
           var result= await _habitService.Create(newHabit);
        }

        
    }
}
