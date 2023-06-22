using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tescaro.GBT.API.Extentions;
using Tescaro.GBT.Appplication.DTOs;
using Tescaro.GBT.Appplication.Interfaces;

namespace Tescaro.GBT.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpGet("GetUser/{email}")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var email = User.GetEmail();
                var user = await _accountService.GetUserByEmailAsync(email);
                return Ok(user);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                if (await _accountService.UserExists(userDTO.Email))
                    return BadRequest("Email já cadastradado.");

                var user = await _accountService.CreateAccountAsync(userDTO);
                if (user != null)
                    return Ok (user);

                return BadRequest("Usuaário não cadastrado. Tente novamente mais tarde.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var user = await _accountService.GetUserByEmailAsync(userLoginDTO.Email);
                if (user == null)
                    return Unauthorized("Usuaário não encontrado.");

                var resultado = await _accountService.CheckUserPasswordAsync(user, userLoginDTO.Password);
                if (resultado == null) return Unauthorized("Usuário ou senha inválidos");


                return Ok(new { 
                    email = user.Email,
                    nome = user.Nome,
                    token = _tokenService.CreateToken(user).Result
            });
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var user = await _accountService.GetUserByEmailAsync(User.GetEmail());
                if (user == null)
                    return Unauthorized("Usuaário não encontrado.");

                var resultado = await _accountService.UpdateAccount(userUpdateDTO);
                if (user == null) return NoContent();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
            }
        }

    }
}
