﻿using Tescaro.GBT.API.DTOs;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface IChamadoService
    {
        Task<ChamadoDTO> AdicionarChamado(ChamadoDTO chamado);
        Task<ChamadoDTO> AtualizarChamado(long chamadoId, ChamadoDTO model);
        Task<bool> ExcluirChamado(long chamadoId);
        Task<List<ChamadoDTO>> GetTodosChamados();
        Task<List<ChamadoDTO>> GetTodosChamadosFromUser(long userId);
        Task<ChamadoDTO> GetChamadoById(long chamadoId);
        Task<List<ChamadoDTO>> GetTodosChamadosByNumero(string numero);
        Task<List<ChamadoDTO>> GetTodosChamadosByCliente(long clienteId);
        Task<List<ChamadoDTO>> GetTodosChamadosByDns(long dnsId);
        Task<List<ChamadoDTO>> GetTodosChamadosByBancoDados(long bancoDadosId);
    }
}
