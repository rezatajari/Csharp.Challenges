using Application.Shared.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            List<TodoItem> todos = await context.TodoItems.ToListAsync();
            if (todos.Count == 0)
                return NoContent();
            return Ok(todos);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById(int Id) {
            TodoItem? item=await context.TodoItems.FirstOrDefaultAsync(item=>item.Id == Id);
            if (item is null)
                return NotFound();
            item.Delete();
            await context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoRequest model)
        {
            TodoItem? item=await context.TodoItems.FirstOrDefaultAsync(t=>t.Id == model.Id);
            if (item is null)
                return NotFound();
            item.Update(model.NewTitle);
            await context.SaveChangesAsync();
            return Ok(item);
        }
    }
}
