﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tescaro.GBT.Domain.Identity;

namespace Tescaro.GBT.Domain.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }

        //public ICollection<Chamado>? Chamados { get; set;}
        //public ICollection<DNS>? DNSs { get; set;}
        //public ICollection<BancoDados>? BancosDados { get; set;}



    }
}
