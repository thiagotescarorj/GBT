using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> AdicionarCliente(Cliente cliente);
        Task<Cliente> AtualisarCliente(long clienteId, Cliente model);
        Task<bool> ExcluirCliente(long clienteId);
        Task<List<Cliente>> GetTodosClientes();
        Task<Cliente> GetClienteById(long clienteId);
        Task<List<Cliente>> GetTodosClientesByNome(string nome);
    }
}
