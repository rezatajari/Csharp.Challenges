using Application.Dtos;
using Application.Interfaces;
using Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;

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
            var result=await _financeService.OpenAccount(createAccModel);
            return (result.IsSuccess)
                ? Ok(ApiResult<bool>.Success(result.Value))
                : BadRequest(ApiResult<bool>.Failure(result.ErrorMessage));
        }
    }
}
