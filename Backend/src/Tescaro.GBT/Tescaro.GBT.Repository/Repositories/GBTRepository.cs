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
    public class GBTRepository : IGBTRepository
    {
        private readonly GBTContext _context;
        public GBTRepository(GBTContext context)
        {
            _context = context;
        }

        public void Adicionar<T>(T entity) 
        {
            _context.Add(entity);
        }

        public void Atualizar<T>(T entity) 
        {
            _context.Update(entity);
        }

        public void Excluir<T>(T entity) 
        {
            _context.Remove(entity);
        }

        public void ExcluirVarios<T>(List<T> entityList) 
        {
            _context.RemoveRange(entityList);
        }




        public async Task<bool> SalvarAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
      
    }
}
