using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Persistence.Interfaces
{
    public  interface IGBTPersistence
    {
        #region Geral
        void Adciionar<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;
        void Excluir<T>(T entity) where T : class;
        void ExcluirVarios<T>(T entity) where T : class;

        Task<bool> SalvarAlteracoesAsync();
        #endregion

        #region Chamado
        Task<Chamado[]> GetTodosChamados();
        Task<Chamado[]> GetChamadoById(long chamadoId);
        Task<Chamado[]> GetTodosChamadosByNumero(long numero);
        Task<Chamado[]> GetTodosChamadosByCliente(string cliente);
        Task<Chamado[]> GetTodosChamadosByDns(string dns);
        Task<Chamado[]> GetTodosChamadosByBancoDados(string dancoDados);
        #endregion

        #region Cliente
        Task<Cliente[]> GetTodosClientes();
        Task<Cliente[]> GetClienteById(long clienteId);
        Task<Cliente[]> GetTodosClientesByNome(long nome);
        #endregion

        #region BancoDados
        Task<BancoDados[]> GetTodosBancoDados();
        Task<BancoDados[]> GetBancoDadosById(long bancoDadosId);
        Task<Chamado[]> GetTodosBancoDadosByCliente(string cliente);
        Task<BancoDados[]> GetTodosBancoDadosByNome(long nome);
        #endregion

        #region DNS
        Task<DNS[]> GetTodosDNS();
        Task<DNS[]> GetDNSById(long dnsId);
        Task<Chamado[]> GetTodosDNSByCliente(string cliente);
        Task<DNS[]> GetTodosDNSByNome(long nome);
        #endregion

    }
}
