﻿namespace Tescaro.GBT.Domain.Models
{
    public class Chamado
    {
        public long Id { get; set; }
        
        public string Numero { get; set; }

        public bool IsAtivo { get; set; }

        public DateTime DataHoraCadastro { get; set; }
        
        public DateTime? DataRecebimento { get; set; }

        public DateTime? DataEnvioHomologacao { get; set; }
        public DateTime? DataPublicacao { get; set; }
              
        public string Observacao { get; set; }
       
        public string ScriptText { get; set; }

        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<Cliente> ClienteList { get; set; }

        public long BancoDadosId { get; set; }
        public BancoDados BancoDados { get; set; }
        public IEnumerable<BancoDados> BancoDadosList { get; set; }

        public long DNSId { get; set; }
        public DNS DNS { get; set; }
        public IEnumerable<DNS> DNSList { get; set; }
        
    }
}
