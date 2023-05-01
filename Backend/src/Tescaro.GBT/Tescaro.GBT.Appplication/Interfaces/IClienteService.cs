using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.API.DTOs;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> AdicionarCliente(ClienteDTO cliente);
        Task<ClienteDTO> AtualizarCliente(long clienteId, ClienteDTO model);
        Task<bool> ExcluirCliente(long clienteId);
        Task<List<ClienteDTO>> GetTodosClientes();
        Task<ClienteDTO> GetClienteById(long clienteId);
        Task<List<ClienteDTO>> GetTodosClientesByNome(string nome);
    }
}
