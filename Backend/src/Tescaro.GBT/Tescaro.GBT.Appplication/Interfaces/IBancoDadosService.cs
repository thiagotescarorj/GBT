using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.API.DTOs;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface IBancoDadosService
    {
        Task<BancoDadosDTO> AdicionarBancoDados(BancoDadosDTO chamado);
        Task<BancoDadosDTO> AtualizarBancoDados(long chamadoId, BancoDadosDTO model);
        Task<bool> ExcluirBancoDados(long chamadoId);
        Task<List<BancoDadosDTO>> GetTodosBancoDados();
        Task<BancoDadosDTO> GetBancoDadosById(long bancoDadosId);
        Task<List<BancoDadosDTO>> GetTodosBancoDadosByCliente(long clienteId);
        Task<List<BancoDadosDTO>> GetTodosBancoDadosByNome(string nome);
    }
}
