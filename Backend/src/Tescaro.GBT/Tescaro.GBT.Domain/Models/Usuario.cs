using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Identity;

namespace Tescaro.GBT.Domain.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
