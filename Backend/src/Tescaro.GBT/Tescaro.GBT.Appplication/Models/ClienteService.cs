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
using Tescaro.GBT.Repository.Repositories;

namespace Tescaro.GBT.Appplication.Models
{
    public class ClienteService : IClienteService
    {
        private readonly IGBTRepository _GBTRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IGBTRepository gBTRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            _GBTRepository = gBTRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> AdicionarCliente(ClienteDTO model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);

                _GBTRepository.Adicionar<Cliente>(cliente);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _clienteRepository.GetClienteById(cliente.Id);

                    return _mapper.Map<ClienteDTO>(retorno) ;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> AtualizarCliente(long clienteId, ClienteDTO model)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(clienteId);
                if (cliente == null) return null;

                model.Id = cliente.Id;

                _mapper.Map(model, cliente);

                _GBTRepository.Atualizar(model);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _clienteRepository.GetClienteById(cliente.Id);

                    return _mapper.Map<ClienteDTO>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirCliente(long clienteId)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(clienteId);
                if (cliente == null)
                {
                    throw new Exception($"Cliente de Id {clienteId} não foi localizado.");
                }
                _GBTRepository.Excluir<Cliente>(cliente);

                return await _GBTRepository.SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ClienteDTO>> GetTodosClientes()
        {
            try
            {
                var clientes = await _clienteRepository.GetTodosClientes();
                
                if (clientes == null) return null;

                var retorno = _mapper.Map<List<ClienteDTO>>(clientes);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> GetClienteById(long clienteId)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(clienteId);
                if (cliente == null) return null;
                
                var retorno = _mapper.Map<ClienteDTO>(cliente);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<ClienteDTO>> GetTodosClientesByNome(string nome)
        {
            try
            {
                var clientes = await _clienteRepository.GetTodosClientesByNome(nome);
                if (clientes == null) return null;

                var retorno = _mapper.Map<List<ClienteDTO>>(clientes);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
