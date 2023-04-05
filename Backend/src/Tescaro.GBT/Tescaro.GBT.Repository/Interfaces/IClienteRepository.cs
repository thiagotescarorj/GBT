using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository.Interfaces
{
    public  interface IClienteRepository : IGBTRepository
    {        
        #region Cliente
        Task<List<Cliente>> GetTodosClientes();
        Task<Cliente> GetClienteById(long clienteId);
        Task<List<Cliente>> GetTodosClientesByNome(string nome);
        #endregion

        
    }
}
