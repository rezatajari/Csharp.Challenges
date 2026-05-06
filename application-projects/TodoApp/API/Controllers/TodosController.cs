using Application.Shared.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            TodoItem? item = await context.TodoItems.FirstOrDefaultAsync(t => t.Id == Id);
            if (item is null) 
                return NotFound();
            return Ok(item);
        }

    }
}
