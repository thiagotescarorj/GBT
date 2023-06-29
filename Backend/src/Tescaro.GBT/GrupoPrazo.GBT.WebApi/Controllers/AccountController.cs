﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tescaro.GBT.API.Extentions;
using Tescaro.GBT.Appplication.DTOs;
using Tescaro.GBT.Appplication.Interfaces;

namespace Tescaro.GBT.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        //private readonly IUtil _util;

        private readonly string _destino = "Perfil";

        public AccountController(IAccountService accountService,
                                 ITokenService tokenService
            //                     IUtil util
            )
        {
           // _util = util;
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var email = User.GetEmail();
                var user = await _accountService.GetUserByEmailAsync(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                if (await _accountService.UserExists(userDTO.Email))
                    return BadRequest("Usuário já existe");

                var user = await _accountService.CreateAccountAsync(userDTO);
                if (user != null)
                    return Ok(new
                    {
                        email = user.Email,
                        token = _tokenService.CreateToken(user).Result
                    });

                return BadRequest("Usuário não criado, tente novamente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Registrar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            try
            {
                var user = await _accountService.GetUserByEmailAsync(userLogin.Email);
                if (user == null) return Unauthorized("Usuário ou Senha está errado");

                var result = await _accountService.CheckUserPasswordAsync(user, userLogin.Password);
                if (!result.Succeeded) return Unauthorized();

                return Ok(new
                {
                    email = user.Email,                    
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar Login. Erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                if (userUpdateDTO.Email != User.GetEmail())
                    return Unauthorized("Usuário Inválido");

                var user = await _accountService.GetUserByEmailAsync(User.GetEmail());
                if (user == null) return Unauthorized("Usuário Inválido");

                var userReturn = await _accountService.UpdateAccount(userUpdateDTO);
                if (userReturn == null) return NoContent();

                return Ok(new
                {
                    email = userReturn.Email,
                    token = _tokenService.CreateToken(userReturn).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage()
        {
            try
            {
                var user = await _accountService.GetUserByEmailAsync(User.GetEmail());
                if (user == null) return NoContent();

                var file = Request.Form.Files[0];
                //if (file.Length > 0)
                //{
                //    _util.DeleteImage(user.ImagemURL, _destino);
                //    user.ImagemURL = await _util.SaveImage(file, _destino);
                //}
                var userRetorno = await _accountService.UpdateAccount(user);

                return Ok(userRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar upload de Foto do Usuário. Erro: {ex.Message}");
            }
        }
    }

    //[Authorize]
    //[ApiController]
    //[Route("api/[controller]")]
    //public class AccountController : Controller
    //{
    //    private readonly IAccountService _accountService;
    //    private readonly ITokenService _tokenService;

    //    public AccountController(IAccountService accountService, ITokenService tokenService)
    //    {
    //        _accountService = accountService;
    //        _tokenService = tokenService;
    //    }

    //    [HttpGet()]
    //    [Route("GetUser")]
    //    public async Task<IActionResult> GetUser()
    //    {
    //        try
    //        {
    //            var email = User.GetEmail();
    //            var user = await _accountService.GetUserByEmailAsync(email);
    //            return Ok(user);
    //        }
    //        catch (Exception e)
    //        {
    //            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
    //        }
    //    }

    //    [HttpPost("Register")]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> Register(UserDTO userDTO)
    //    {
    //        try
    //        {
    //            if (await _accountService.UserExists(userDTO.Email))
    //                return BadRequest("Email já cadastradado.");

    //            var user = await _accountService.CreateAccountAsync(userDTO);
    //            if (user != null)
    //                return Ok (user);

    //            return BadRequest("Usuaário não cadastrado. Tente novamente mais tarde.");
    //        }
    //        catch (Exception e)
    //        {
    //            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
    //        }
    //    }

    //    [HttpPost("Login")]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
    //    {
    //        try
    //        {
    //            var user = await _accountService.GetUserByEmailAsync(userLoginDTO.Email);
    //            if (user == null)
    //                return Unauthorized("Usuaário não encontrado.");

    //            var resultado = await _accountService.CheckUserPasswordAsync(user, userLoginDTO.Password);
    //            if (resultado == null) return Unauthorized("Usuário ou senha inválidos");


    //            return Ok(new { 
    //                email = user.Email,
    //                nome = user.Nome,
    //                token = _tokenService.CreateToken(user).Result
    //        });
    //        }
    //        catch (Exception e)
    //        {
    //            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
    //        }
    //    }

    //    [HttpPut("UpdateUser")]
    //    public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
    //    {
    //        try
    //        {
    //            var user = await _accountService.GetUserByEmailAsync(User.GetEmail());
    //            if (user == null)
    //                return Unauthorized("Usuaário não encontrado.");

    //            var resultado = await _accountService.UpdateAccount(userUpdateDTO);
    //            if (user == null) return NoContent();

    //            return Ok(resultado);
    //        }
    //        catch (Exception e)
    //        {
    //            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}"); ;
    //        }
    //    }

    //}


}
