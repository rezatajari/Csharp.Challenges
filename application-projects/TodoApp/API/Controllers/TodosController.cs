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
        public async Task<IActionResult> Create(CreateTodoForm formModel, CancellationToken ct)
        {
            Result<TodoItem> result = await todoService.CreateTodoItem(formModel, ct);
            return HandleResult(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
            Result<TodoItem> result = await todoService.GetById(Id, ct);
            return HandleResult(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            Result<List<TodoItem>> result = await todoService.GetAll(ct);
            return HandleResult(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById(int Id, CancellationToken ct)
        {
            Result<bool> result = await todoService.Delete(Id, ct);
            return HandleResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoRequest model, CancellationToken ct)
        {
            Result<bool> result = await todoService.Update(model, ct);
            return HandleResult(result);
        }


    }
}
