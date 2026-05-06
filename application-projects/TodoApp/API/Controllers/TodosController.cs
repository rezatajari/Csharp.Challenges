using Application.Shared.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController(TodoAppDb context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoForm formModel)
        {
            TodoItem item = TodoItem.Create(formModel.Title);
            await context.AddAsync(item);
            await context.SaveChangesAsync();
            return Ok(item);
        }
    }
}
