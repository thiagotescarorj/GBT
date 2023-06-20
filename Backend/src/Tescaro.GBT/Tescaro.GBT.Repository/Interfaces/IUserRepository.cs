using Tescaro.GBT.Domain.Identity;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository.Interfaces
{
    public  interface IUserRepository : IGBTRepository
    {        
        #region User
        Task<List<User>> GetTodosUsers();
        Task<User> GetUserById(long userId);
        Task<User> GetUserByEmailAsync(string email);

        #endregion

    }
}
