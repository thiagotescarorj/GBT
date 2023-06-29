using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Tescaro.GBT.Appplication.DTOs;
using Tescaro.GBT.Appplication.Interfaces;
using Tescaro.GBT.Domain.Identity;
using Tescaro.GBT.Repository.Interfaces;

namespace Tescaro.GBT.Appplication.Services
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public  AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDTO, string password)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == userUpdateDTO.Email.ToLower());
                return await _signInManager.CheckPasswordSignInAsync(user, password, false);

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> CreateAccountAsync(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                user.UserName = userDTO.Email;
                user.NomeCompleto = userDTO.Nome + " " + userDTO.Sobrenome;

                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (result.Succeeded)
                {
                    return _mapper.Map<UserUpdateDTO>(user);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(email);
                if (user == null) return null;

                return _mapper.Map<UserUpdateDTO>(user);    

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var user = await _userRepository.GetUserById(userUpdateDTO.Id);
                if (user == null) return null;

                //if (userUpdateDTO.Nome.ToLower() != user.Nome.ToLower() || userUpdateDTO.Sobrenome.ToLower() != user.Sobrenome.ToLower()) 
                //{
                //    user.NomeCompleto = userUpdateDTO.Nome + " " + userUpdateDTO.Sobrenome;
                //}

                _mapper.Map(userUpdateDTO, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, userUpdateDTO.Password);

                _userRepository.Atualizar<User>(user);

                if (await _userRepository.SalvarAlteracoesAsync())
                {
                    var userRetorno = await _userRepository.GetUserById(user.Id);

                    return _mapper.Map<UserUpdateDTO>(userRetorno);
                }

                return null;

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string username)
        {
            try
            {
                return await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
