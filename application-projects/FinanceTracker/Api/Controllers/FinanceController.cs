using Application.Dtos.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinanceController(IFinanceService financeService, ILogger<FinanceController> logger) 
        : ApiControllerBase
    {
        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount(CreateAccountRequest createAccModel, CancellationToken ct)
        {
            logger.LogInformation("Received request to create account: {AccountName}", createAccModel.Name);
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            var result = await financeService.OpenAccount(createAccModel,UserId, ct);
            return HandleResult(result);
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAllAccounts(CancellationToken ct)
        {
            logger.LogInformation("Received request to fetch all accounts");
            var result = await financeService.GetAccounts(ct);
            return HandleResult(result);
        }

        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetAccount(int id, CancellationToken ct)
        {
            logger.LogInformation("Received request for Account Details. Id: {AccountId}", id);
            var result = await financeService.GetAccount(id, ct);
            return HandleResult(result);
        }
        
        [HttpGet("transaction/{id}")]
        public async Task<IActionResult> GetTransaction(int id, CancellationToken ct)
        {
            logger.LogInformation("Received request for Transactions. AccountId: {AccountId}", id);
            var result = await financeService.GetAccountTransactions(id, ct);
            return HandleResult(result);
        }

        [HttpPost("transaction")]
        public async Task<IActionResult> AddTransaction(AddTransactionRequest request, CancellationToken ct)
        {
            logger.LogInformation("Received request to add {TransactionType} for AccountId: {AccountId}",
                request.Type, request.AccountId);

            var result = await financeService.AddTransaction(request, ct);
            return HandleResult(result);
        }

        [Authorize]
        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard(CancellationToken ct)
        {
            var result = await financeService.GetDashboard(UserId, ct);
            return HandleResult(result);
        }
    }
}