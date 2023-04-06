using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface IBancoDadosService
    {
        Task<BancoDados> AdicionarBancoDados(BancoDados chamado);
        Task<BancoDados> AtualisarBancoDados(long chamadoId, BancoDados model);
        Task<bool> ExcluirBancoDados(long chamadoId);
        Task<List<BancoDados>> GetTodosBancoDados();
        Task<BancoDados> GetBancoDadosById(long bancoDadosId);
        Task<List<BancoDados>> GetTodosBancoDadosByCliente(long clienteId);
        Task<List<BancoDados>> GetTodosBancoDadosByNome(string nome);
    }
}
