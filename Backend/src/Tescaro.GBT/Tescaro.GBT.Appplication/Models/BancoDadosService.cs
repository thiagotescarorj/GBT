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
    public class BancoDadosService : IBancoDadosService
    {
        private readonly IGBTRepository _GBTRepository;
        private readonly IBancoDadosRepository _bancoDadosRepository;

        public BancoDadosService(IGBTRepository gBTRepository, IBancoDadosRepository bancoDadosRepository)
        {
            _GBTRepository = gBTRepository;
            _bancoDadosRepository = bancoDadosRepository;
        }

        public async Task<BancoDados> AdicionarBancoDados(BancoDados bancoDados)
        {
            try
            {
                _GBTRepository.Adicionar<BancoDados>(bancoDados);
                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    return await _bancoDadosRepository.GetBancoDadosById(bancoDados.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BancoDados> AtualizarBancoDados(long bancoDadosId, BancoDados model)
        {
            try
            {
                var bancoDado = await _bancoDadosRepository.GetBancoDadosById(bancoDadosId);
                if (bancoDado == null) return null;

                model.Id = bancoDado.Id;

                _GBTRepository.Atualizar(model);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    return await _bancoDadosRepository.GetBancoDadosById(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirBancoDados(long bancoDadosId)
        {
            try
            {
                var bancoDados = await _bancoDadosRepository.GetBancoDadosById(bancoDadosId);
                if (bancoDados == null)
                {
                    throw new Exception($"Banco de Dados de Id {bancoDadosId} não foi localizado.");
                }
                _GBTRepository.Excluir<BancoDados>(bancoDados);

                return await _GBTRepository.SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BancoDados>> GetTodosBancoDados()
        {
            try
            {
                var bancosDados = await _bancoDadosRepository.GetTodosBancoDados();
                if (bancosDados == null) return null;
                return bancosDados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BancoDados> GetBancoDadosById(long bancoDadosId)
        {
            try
            {
                var bancosDados = await _bancoDadosRepository.GetBancoDadosById(bancoDadosId);
                if (bancosDados == null) return null;
                return bancosDados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<BancoDados>> GetTodosBancoDadosByCliente(long clienteId)
        {
            try
            {
                var bancosDados = await _bancoDadosRepository.GetTodosBancoDadosByCliente(clienteId);
                if (bancosDados == null) return null;
                return bancosDados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BancoDados>> GetTodosBancoDadosByNome(string nome)
        {
            try
            {
                var bancosDados = await _bancoDadosRepository.GetTodosBancoDadosByNome(nome);
                if (bancosDados == null) return null;
                return bancosDados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
