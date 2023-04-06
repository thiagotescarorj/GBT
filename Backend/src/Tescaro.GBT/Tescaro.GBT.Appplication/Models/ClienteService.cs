using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ClienteService(IGBTRepository gBTRepository, IClienteRepository clienteRepository)
        {
            _GBTRepository = gBTRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            try
            {
                _GBTRepository.Adicionar<Cliente>(cliente);
                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    return await _clienteRepository.GetClienteById(cliente.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> AtualisarCliente(long clienteId, Cliente model)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(clienteId);
                if (cliente == null) return null;

                model.Id = cliente.Id;

                _GBTRepository.Atualisar(model);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    return await _clienteRepository.GetClienteById(model.Id);
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
        public async Task<List<Cliente>> GetTodosClientes()
        {
            try
            {
                var clientes = await _clienteRepository.GetTodosClientes();
                if (clientes == null) return null;
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> GetClienteById(long clienteId)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(clienteId);
                if (cliente == null) return null;
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<Cliente>> GetTodosClientesByNome(string nome)
        {
            try
            {
                var clientes = await _clienteRepository.GetTodosClientesByNome(nome);
                if (clientes == null) return null;
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
