using Application.IServieces;
using Application.Shared;
using Application.Shared.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController(ITodoService todoService) : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoForm formModel,CancellationToken ct)
        {
            Result<TodoItem> result = await todoService.CreateTodoItem(formModel, ct);
            return HandleResult(result);
          
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
                Result<TodoItem> todoItem = await todoService.GetById(Id, ct);
                return HandleResult(todoItem);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll( CancellationToken ct)
        {
            List<TodoItem> todos = await context.TodoItems.ToListAsync();
            if (todos.Count == 0)
                return NoContent();
            return Ok(todos);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById(int Id, CancellationToken ct) {
            TodoItem? item=await context.TodoItems.FirstOrDefaultAsync(item=>item.Id == Id);
            if (item is null)
                return NotFound();
            item.Delete();
            await context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoRequest model, CancellationToken ct)
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
