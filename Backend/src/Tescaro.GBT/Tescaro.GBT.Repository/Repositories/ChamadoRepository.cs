using Microsoft.EntityFrameworkCore;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Repository.Interfaces;

namespace Tescaro.GBT.Repository.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly GBTContext _context;
        

        public ChamadoRepository(GBTContext context)
        {
            _context = context;
        
        }

        public void Adicionar<Chamado>(Chamado chamado)
        {
            _context.Add(chamado);
        }

        public void Atualizar<Chamado>(Chamado chamado)
        {
            _context.Update(chamado);
        }

        public void Excluir<Chamado>(Chamado chamado)
        {
            _context.Remove(chamado);
        }

        public void ExcluirVarios<Chamado>(List<Chamado> chamadoList)
        {
            _context.RemoveRange(chamadoList);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) >0 ;
        }

        public async Task<Chamado> GetChamadoById(long chamadoId)
        {
            IQueryable<Chamado> query = _context.Chamado; 
            
            return await query.Where(x => x.Id == chamadoId).FirstOrDefaultAsync();

            
        }

        public  List<Chamado> GetTodosChamados()
        {
            IQueryable<Chamado> query = _context.Chamado.AsQueryable();
                           //.Include(x => x.BancoDadosId)
                           //.Include(x => x.DNSId)
                           //.Include(x => x.ClienteId).AsQueryable();
            if (query == null) 
            {
                return null;
            }
            return query.ToList();
        }

        public List<Chamado> GetTodosChamadosFromUser(long userId)
        {
            IQueryable<Chamado> query = _context.Chamado.Where(x => x.Id == userId).AsQueryable();
            //.Include(x => x.BancoDadosId)
            //.Include(x => x.DNSId)
            //.Include(x => x.ClienteId).AsQueryable();
            if (query == null)
            {
                return null;
            }
            return query.ToList();
        }

        public async Task<List<Chamado>> GetTodosAtivosChamados()
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.Where(x => x.IsAtivo == true).ToListAsync();
        }

        public async Task<List<Chamado>> GetTodosChamadosByBancoDados(long bancoDadosId)
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.Where(x => x.IsAtivo == true && x.BancoDadosId == bancoDadosId).ToListAsync();
        }

        public async Task<List<Chamado>> GetTodosChamadosByCliente(long clienteId)
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.Where(x => x.IsAtivo == true && x.ClienteId == clienteId).ToListAsync();
        }

        public async Task<List<Chamado>> GetTodosChamadosByDns(long dnsId)
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.Where(x => x.IsAtivo == true && x.DNSId == dnsId).ToListAsync();
        }

        public async Task<List<Chamado>> GetTodosChamadosByNumero(string numero)
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.Where(x => x.IsAtivo == true && x.Numero.Contains(numero)).ToListAsync();
        }

        
    }
}
