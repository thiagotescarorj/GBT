using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Appplication.Interfaces;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Repository.Interfaces;

namespace Tescaro.GBT.Appplication.Models
{
    public class ChamadoService : IChamadoService
    {
        private readonly IGBTRepository _GBTRepository;
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoService(IGBTRepository gBTRepository, IChamadoRepository chamadoRepository)
        {
            _GBTRepository = gBTRepository;
            _chamadoRepository = chamadoRepository;
        }

        public async Task<Chamado> AdicionarChamado(Chamado chamado)
        {
            try
            {
                _GBTRepository.Adicionar<Chamado>(chamado);
                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    return await _chamadoRepository.GetChamadoById(chamado.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Chamado> AtualizarChamado(long chamadoId, Chamado model)
        {
            try
            {
                var chamado = await _chamadoRepository.GetChamadoById(chamadoId);
                if (chamado == null) return null;

                model.Id = chamado.Id;

                _GBTRepository.Atualizar(model);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    return await _chamadoRepository.GetChamadoById(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirChamado(long chamadoId)
        {
            try
            {
                var chamado = await _chamadoRepository.GetChamadoById(chamadoId);
                if (chamado == null)
                {
                    throw new Exception($"Chamado de Id {chamadoId} não foi localizado.");
                }
                _GBTRepository.Excluir<Chamado>(chamado);

                return await _GBTRepository.SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Chamado>> GetTodosChamados()
        {
            try
            {
                var chamados =  _chamadoRepository.GetTodosChamados();
                if (chamados == null) return null;
                return chamados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Chamado> GetChamadoById(long chamadoId)
        {
            try
            {
                var chamado = await _chamadoRepository.GetChamadoById(chamadoId);
                if (chamado == null) return null;
                return chamado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       

        public async Task<List<Chamado>> GetTodosChamadosByBancoDados(long bancoDadosId)
        {
            try
            {
                var chamados = await _chamadoRepository.GetTodosChamadosByBancoDados(bancoDadosId);
                if (chamados == null) return null;
                return chamados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Chamado>> GetTodosChamadosByCliente(long clienteId)
        {
            try
            {
                var chamados = await _chamadoRepository.GetTodosChamadosByCliente(clienteId);
                if (chamados == null) return null;
                return chamados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Chamado>> GetTodosChamadosByDns(long dnsId)
        {
            try
            {
                var chamados = await _chamadoRepository.GetTodosChamadosByDns(dnsId);
                if (chamados == null) return null;
                return chamados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Chamado>> GetTodosChamadosByNumero(string numero)
        {
            try
            {
                var chamados = await _chamadoRepository.GetTodosChamadosByNumero(numero);
                if (chamados == null) return null;
                return chamados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
