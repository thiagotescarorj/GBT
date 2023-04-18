using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tescaro.GBT.Domain.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        [MaxLength(255)]
        public string Nome { get; set; }

        [Display(Name = "Ativo")]
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }

        public ICollection<Chamado>? Chamados { get; set;}
        public ICollection<DNS>? DNSs { get; set;}
        public ICollection<BancoDados>? BancosDados { get; set;}

    }
}
