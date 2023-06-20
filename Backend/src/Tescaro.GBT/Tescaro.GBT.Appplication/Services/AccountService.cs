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


        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDTO, string passwoord)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == userUpdateDTO.Email.ToLower());
                return await _signInManager.CheckPasswordSignInAsync(user, passwoord, false);

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<UserDTO> CreateAccountAsync(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                user.UserName = userDTO.Email;

                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (result.Succeeded)
                {
                    return _mapper.Map<UserDTO>(user);
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
