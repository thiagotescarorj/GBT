using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.API.DTOs;
using Tescaro.GBT.Appplication.Interfaces;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Repository.Interfaces;

namespace Tescaro.GBT.Appplication.Models
{
    public class ChamadoService : IChamadoService
    {
        private readonly IGBTRepository _GBTRepository;
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IMapper _mapper;

        public ChamadoService(IGBTRepository gBTRepository,
                              IChamadoRepository chamadoRepository,
                              IMapper mapper)
        {
            _GBTRepository = gBTRepository;
            _chamadoRepository = chamadoRepository;
            _mapper = mapper;
        }

        public async Task<ChamadoDTO> AdicionarChamado(ChamadoDTO model)
        {
            try
            {
                var chamado = _mapper.Map<Chamado>(model);

                _GBTRepository.Adicionar<Chamado>(chamado);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _chamadoRepository.GetChamadoById(chamado.Id);
                    return _mapper.Map<ChamadoDTO>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ChamadoDTO> AtualizarChamado(long chamadoId, ChamadoDTO model)
        {
            try
            {
                var chamado = await _chamadoRepository.GetChamadoById(chamadoId);
                if (chamado == null) return null;

                model.Id = chamado.Id;

                _mapper.Map(model, chamado);

                _GBTRepository.Atualizar(model);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _chamadoRepository.GetChamadoById(chamado.Id);
                    return _mapper.Map<ChamadoDTO>(retorno);
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

        public async Task<List<ChamadoDTO>> GetTodosChamados()
        {
            try
            {
                var chamados = _chamadoRepository.GetTodosChamados();
                if (chamados == null) return null;

                var resultado = _mapper.Map<List<ChamadoDTO>>(chamados);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ChamadoDTO> GetChamadoById(long chamadoId)
        {
            try
            {
                var chamado = await _chamadoRepository.GetChamadoById(chamadoId);
                if (chamado == null) return null;

                var resultado = _mapper.Map<ChamadoDTO>(chamado);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ChamadoDTO>> GetTodosChamadosByBancoDados(long bancoDadosId)
        {
            try
            {
                var chamados = await _chamadoRepository.GetTodosChamadosByBancoDados(bancoDadosId);
                if (chamados == null) return null;

                var resultado = _mapper.Map<List<ChamadoDTO>>(chamados);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ChamadoDTO>> GetTodosChamadosByCliente(long clienteId)
        {
            try
            {
                var chamados = await _chamadoRepository.GetTodosChamadosByCliente(clienteId);
                if (chamados == null) return null;

                var resultado = _mapper.Map<List<ChamadoDTO>>(chamados);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ChamadoDTO>> GetTodosChamadosByDns(long dnsId)
        {
            try
            {
                var chamados = await _chamadoRepository.GetTodosChamadosByDns(dnsId);

                var resultado = _mapper.Map<List<ChamadoDTO>>(chamados);

                if (resultado == null) return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ChamadoDTO>> GetTodosChamadosByNumero(string numero)
        {
            try
            {
                var chamados = await _chamadoRepository.GetTodosChamadosByNumero(numero);
                if (chamados == null) return null;

                var resultado = _mapper.Map<List<ChamadoDTO>>(chamados);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
