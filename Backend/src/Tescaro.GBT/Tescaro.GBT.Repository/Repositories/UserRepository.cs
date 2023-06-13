using Microsoft.EntityFrameworkCore;
using Tescaro.GBT.Domain.Identity;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Repository.Interfaces;

namespace Tescaro.GBT.Repository.Repositories
{
    public class UserRepository :  GBTRepository, IUserRepository
    {
        private readonly GBTContext _context;

        public UserRepository(GBTContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(long userId)
        {
            IQueryable<User> query = _context.Users.Where(x => x.Id == userId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetTodosUsers()
        {
            IQueryable<User> query = _context.Users.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<List<User>> GetTodosAtivosUsers()
        {
            IQueryable<User> query = _context.Users.Where(x => x.IsAtivo == true).AsNoTracking();
            return await query.ToListAsync();
        }

    }
}
