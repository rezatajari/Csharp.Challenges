using Application.Shared.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private List<TodoItem> _todoItems=new List<TodoItem>();
        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoForm formModel)
        {
            TodoItem item = TodoItem.Create(formModel.Title);
            _todoItems.Add(item);
            return Ok(item);
        }
    }
}
