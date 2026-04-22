using Application.Dtos;
using Application.Interfaces;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceService _financeService;
        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto createAccModel)
        {
            var result = await _financeService.OpenAccount(createAccModel);
            return (result.IsSuccess)
                ? Ok(ApiResult<bool>.Success(result.Value))
                : BadRequest(ApiResult<bool>.Failure(result.ErrorMessage));
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var result = await _financeService.GetAccounts();
            return (result.IsSuccess)
                 ? Ok(ApiResult<List<AccountDto>?>.Success(result.Value))
                 : BadRequest(ApiResult<List<AccountDto>>.Failure(result.ErrorMessage));
        }

        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var result = await _financeService.GetAccount(id);
            return (result.IsSuccess)
                ? Ok(ApiResult<AccountDto>.Success(result.Value))
                : BadRequest(ApiResult<AccountDto>.Failure(result.ErrorMessage));
        }

        [HttpGet("transaction/{id}")]
        public async Task<IActionResult> GetTransaction(int id) { 
            var result=_financeService.
        }
    }
}
