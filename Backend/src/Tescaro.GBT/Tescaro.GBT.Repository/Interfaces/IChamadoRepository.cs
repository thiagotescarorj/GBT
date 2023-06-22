using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository.Interfaces
{
    public  interface IChamadoRepository : IGBTRepository
    {

        #region Chamado
        List<Chamado> GetTodosChamados();
        List<Chamado> GetTodosChamadosFromUser(long userId);
        Task<Chamado> GetChamadoById(long chamadoId);
        Task<List<Chamado>> GetTodosChamadosByNumero(string numero);
        Task<List<Chamado>> GetTodosChamadosByCliente(long clienteId);
        Task<List<Chamado>> GetTodosChamadosByDns(long dnsId);
        Task<List<Chamado>> GetTodosChamadosByBancoDados(long bancoDadosId);
        #endregion

        

    }
}
