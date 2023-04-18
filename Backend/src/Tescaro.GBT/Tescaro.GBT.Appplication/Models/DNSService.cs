﻿using System;
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
    public class DNSService : IDNSService
    {
        private readonly IGBTRepository _GBTRepository;
        private readonly IDNSRepository _dnsRepository;

        public DNSService(IGBTRepository gBTRepository, IDNSRepository dnsRepository)
        {
            _GBTRepository = gBTRepository;
            _dnsRepository = dnsRepository;
        }
        public async Task<DNS> AdicionarDNS(DNS dns)
        {
            try
            {
                _GBTRepository.Adicionar<DNS>(dns);
                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    return await _dnsRepository.GetDNSById(dns.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DNS> AtualizarDNS(long dnsId, DNS model)
        {
            try
            {
                var dns = await _dnsRepository.GetDNSById(dnsId);
                if (dns == null) return null;

                model.Id = dns.Id;

                _GBTRepository.Atualizar(model);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    return await _dnsRepository.GetDNSById(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirDNS(long dnsId)
        {
            try
            {
                var dns = await _dnsRepository.GetDNSById(dnsId);
                if (dns == null)
                {
                    throw new Exception($"DNS de Id {dnsId} não foi localizado.");
                }
                _GBTRepository.Excluir<DNS>(dns);

                return await _GBTRepository.SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<DNS>> GetTodosDNS()
        {
            try
            {
                var dnsList = await _dnsRepository.GetTodosDNS();
                if (dnsList == null) return null;
                return dnsList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DNS> GetDNSById(long dnsId)
        {
            try
            {
                var dns = await _dnsRepository.GetDNSById(dnsId);
                if (dns == null) return null;
                return dns;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<DNS>> GetTodosDNSByCliente(long clienteId)
        {
            try
            {
                var dnsList = await _dnsRepository.GetTodosDNSByCliente(clienteId);
                if (dnsList == null) return null;
                return dnsList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DNS>> GetTodosDNSByNome(string nome)
        {
            try
            {
                var dnsList = await _dnsRepository.GetTodosDNSByNome(nome);
                if (dnsList == null) return null;
                return dnsList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}