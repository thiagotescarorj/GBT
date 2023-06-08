﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections;
using Tescaro.GBT.Domain.Identity;

namespace Tescaro.GBT.Domain.Models
{
    public class BancoDados
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public bool IsAtivo { get; set; }

        public DateTime DataHoraCadastro { get; set; }

        
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
