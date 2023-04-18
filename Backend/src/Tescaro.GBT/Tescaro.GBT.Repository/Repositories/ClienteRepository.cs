using Microsoft.EntityFrameworkCore;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Repository.Interfaces;

namespace Tescaro.GBT.Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly GBTContext _context;

        public ClienteRepository(GBTContext context)
        {
            _context = context;
        }

        public void Adicionar<Cliente>(Cliente cliente)
        {
            _context.Add(cliente);
        }

        public void Atualizar<Cliente>(Cliente cliente)
        {
            _context.Update(cliente);
        }

        public void Excluir<Cliente>(Cliente cliente)
        {
            _context.Remove(cliente);
        }

        public void ExcluirVarios<Cliente>(List<Cliente> clienteList)
        {
            _context.RemoveRange(clienteList);
        }

        public async Task<Cliente> GetClienteById(long clienteId)
        {
            IQueryable<Cliente> query = _context.Cliente.Where(x => x.Id == clienteId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Cliente>> GetTodosClientes()
        {
            IQueryable<Cliente> query = _context.Cliente.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<List<Cliente>> GetTodosAtivosClientes()
        {
            IQueryable<Cliente> query = _context.Cliente.Where(x => x.IsAtivo == true).AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<List<Cliente>> GetTodosClientesByNome(string nome)
        {
            IQueryable<Cliente> query = _context.Cliente.Where(x => x.Nome.Contains(nome)).AsNoTracking();
            return await query.ToListAsync();
        }

        public Task<bool> SalvarAlteracoesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
