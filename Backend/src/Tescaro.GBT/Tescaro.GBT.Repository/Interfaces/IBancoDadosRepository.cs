using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository.Interfaces
{
    public  interface IBancoDadosRepository : IGBTRepository
    {
        #region BancoDados
        Task<List<BancoDados>> GetTodosBancoDados();
        Task<BancoDados> GetBancoDadosById(long bancoDadosId);
        Task<List<BancoDados>> GetTodosBancoDadosByCliente(long clienteId);
        Task<List<BancoDados>> GetTodosBancoDadosByNome(string nome);
        #endregion

    }
}
