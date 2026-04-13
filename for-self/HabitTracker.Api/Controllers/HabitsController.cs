using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateHabit()
        {
            return Created("", null);
        }
    }
}
