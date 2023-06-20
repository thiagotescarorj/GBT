using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tescaro.GBT.Appplication.Interfaces;

namespace Tescaro.GBT.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                return null;
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
            }
        }

    }
}
