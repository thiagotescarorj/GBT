using Microsoft.AspNetCore.Identity;
using Tescaro.GBT.Appplication.DTOs;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface IAccountService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDTO> GetUserByEmailAsync(string email);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDTO, string passwoord);
        Task<UserDTO> CreateAccountAsync(UserDTO userDTO);
        Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDTO); 
    }
}
