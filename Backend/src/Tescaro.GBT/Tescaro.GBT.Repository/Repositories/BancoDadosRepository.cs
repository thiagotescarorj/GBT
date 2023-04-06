using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Repository.Interfaces;

namespace Tescaro.GBT.Repository.Repositories
{
    public class BancoDadosRepository : IBancoDadosRepository
    {
        private readonly GBTContext _context;

        public BancoDadosRepository(GBTContext context)
        {
            _context = context;
        }

        public void Adicionar<BancoDados>(BancoDados bancoDados)
        {
            _context.Add(bancoDados);
        }

        public void Atualisar<BancoDados>(BancoDados bancoDados)
        {
            _context.Update(bancoDados);
        }

        public void Excluir<BancoDados>(BancoDados bancoDados)
        {
            _context.Remove(bancoDados);
        }

        public void ExcluirVarios<BancoDados>(List<BancoDados> bancoDadosList)
        {
            _context.RemoveRange(bancoDadosList);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<BancoDados> GetBancoDadosById(long bancoDadosId)
        {
            IQueryable<BancoDados> query = _context.BancoDados.Where(x => x.Id == bancoDadosId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<BancoDados>> GetTodosBancoDados()
        {
            IQueryable<BancoDados> query = _context.BancoDados;
            return await query.ToListAsync();
        }

        public async Task<List<BancoDados>> GetTodosBancoDadosByCliente(long clienteId)
        {
            IQueryable<BancoDados> query = _context.BancoDados.Where(x => x.Cliente.Id == clienteId);
            return await query.ToListAsync();
        }

        public async Task<List<BancoDados>> GetTodosBancoDadosByNome(string nome)
        {
            IQueryable<BancoDados> query = _context.BancoDados.Where(x => x.Nome.Contains(nome));
            return await query.ToListAsync();
        }


    }
}
