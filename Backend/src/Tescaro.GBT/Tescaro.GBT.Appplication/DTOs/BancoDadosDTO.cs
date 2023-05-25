using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tescaro.GBT.API.DTOs
{
    public class BancoDadosDTO
    {
        public long Id { get; set; }
        [Required]
        public string? Nome { get; set; }

        [Display(Name = "Ativo")]
        public bool IsAtivo { get; set; }

        [Display(Name = "Data Hora Cadastro")]
        public DateTime? DataHoraCadastro { get; set; }

        public long ClienteId { get; set; }


    }
}
