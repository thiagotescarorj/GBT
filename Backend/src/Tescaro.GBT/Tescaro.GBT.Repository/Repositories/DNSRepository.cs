using Microsoft.EntityFrameworkCore;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Repository.Interfaces;

namespace Tescaro.GBT.Repository.Repositories
{
    public class DNSRepository : IDNSRepository
    {
        private readonly GBTContext _context;

        public DNSRepository(GBTContext context)
        {
            _context = context;
        }

        public void Adicionar<DNS>(DNS dns)
        {
            _context.Add(dns);
        }

        public void Atualizar<DNS>(DNS dns)
        {
            _context.Update(dns);
        }

        public void Excluir<DNS>(DNS dns)
        {
            _context.Remove(dns);
        }

        public void ExcluirVarios<DNS>(List<DNS> dnsList)
        {
            _context.RemoveRange(dnsList);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<DNS> GetDNSById(long dnsId)
        {
            IQueryable<DNS> query = _context.DNS.Where(x => x.Id == dnsId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<DNS>> GetTodosDNS()
        {
            IQueryable<DNS> query = _context.DNS;
            return await query.ToListAsync();
        }

        public async Task<List<DNS>> GetTodosDNSByCliente(long clienteId)
        {
            IQueryable<DNS> query = _context.DNS.Include(x => x.ClienteId).Where(x => x.ClienteId == clienteId);
            return await query.ToListAsync();
        }

        public async Task<List<DNS>> GetTodosDNSByNome(string nome)
        {
            IQueryable<DNS> query = _context.DNS.Include(x => x.ClienteId).Where(x => x.Nome.Contains(nome));
            return await query.ToListAsync();
        }

        
    }
}
