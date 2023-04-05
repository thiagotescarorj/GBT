using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tescaro.GBT.Domain.Models
{
    public class DNS
    {
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Ativo")]
        public bool IsAtivo { get; set; }

        [Display(Name = "Em Atividade")]
        public bool IsAtividade { get; set; }

        [Display(Name = "Data Hora Cadastro")]
        public DateTime DataHoraCadastro { get; set; }
        public bool IsSemDNSAteMOMENTO { get; set; }
        public bool IsSemDNS { get; set; }

        public Cliente Cliente { get; set; }
        public IEnumerable<Cliente> ClienteList { get; set; }

    }
}
