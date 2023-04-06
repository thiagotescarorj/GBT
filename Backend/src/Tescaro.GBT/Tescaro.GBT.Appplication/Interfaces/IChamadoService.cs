using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface IChamadoService
    {
        Task<Chamado> AdicionarChamado(Chamado chamado);
        Task<Chamado> AtualisarChamado(long chamadoId, Chamado model);
        Task<bool> ExcluirChamado(long chamadoId);
        Task<List<Chamado>> GetTodosChamados();
        Task<Chamado> GetChamadoById(long chamadoId);
        Task<List<Chamado>> GetTodosChamadosByNumero(string numero);
        Task<List<Chamado>> GetTodosChamadosByCliente(long clienteId);
        Task<List<Chamado>> GetTodosChamadosByDns(long dnsId);
        Task<List<Chamado>> GetTodosChamadosByBancoDados(long bancoDadosId);
    }
}
