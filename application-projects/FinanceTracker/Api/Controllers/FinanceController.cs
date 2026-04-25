using Application.Dtos;
using Application.Interfaces;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ApiControllerBase
    {
        private readonly IFinanceService _financeService;
        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto createAccModel,CancellationToken ct)
        {
            var result = await _financeService.OpenAccount(createAccModel,ct);
            return HandleResult(result);
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAllAccounts(CancellationToken ct)
        {
            var result = await _financeService.GetAccounts(ct);
            return HandleResult(result);
        }

        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetAccount(int id, CancellationToken ct)
        {
            var result = await _financeService.GetAccount(id,ct);
            return HandleResult(result);
        }

        [HttpGet("transaction/{id}")]
        public async Task<IActionResult> GetTransaction(int id, CancellationToken ct)
        {
            var result = await _financeService.GetTransactionById(id,ct);
            return HandleResult(result);
        }

        [HttpPost("transaction/add")]
        public async Task<IActionResult> AddTransaction(InputTxDto inputTxDto, CancellationToken ct)
        {
            var result = await _financeService.AddTransaction(inputTxDto,ct);
            return HandleResult(result);
        }
    }
}
