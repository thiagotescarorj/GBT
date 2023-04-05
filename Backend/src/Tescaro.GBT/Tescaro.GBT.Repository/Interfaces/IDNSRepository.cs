using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository.Interfaces
{
    public  interface IDNSRepository : IGBTRepository
    { 
        #region DNS
        Task<List<DNS>> GetTodosDNS();
        Task<DNS> GetDNSById(long dnsId);
        Task<List<DNS>> GetTodosDNSByCliente(long clienteId);
        Task<List<DNS>> GetTodosDNSByNome(string nome);
        #endregion

    }
}
