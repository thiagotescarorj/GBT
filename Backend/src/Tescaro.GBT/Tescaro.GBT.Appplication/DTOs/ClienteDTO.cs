using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tescaro.GBT.API.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }
        
        [MaxLength(255)]
        [Required(ErrorMessage = "o campo Nome é obrígatório")]
        public string? Nome { get; set; }

        [Display(Name = "Ativo")]
        public string? IsAtivo { get; set; }

        [Display(Name = "Data Hora Cadastro")]
        public string? DataHoraCadastro { get; set; }
    }
}
