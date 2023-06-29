using Tescaro.GBT.Domain.Identity;

namespace Tescaro.GBT.Domain.Models
{
    public class DNS
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public bool IsAtivo { get; set; }

    
        public bool IsAtividade { get; set; }

    
        public DateTime DataHoraCadastro { get; set; }

        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }



    }
}
