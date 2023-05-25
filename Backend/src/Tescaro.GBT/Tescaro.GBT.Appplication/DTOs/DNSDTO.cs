using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tescaro.GBT.API.DTOs
{
    public class DNSDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obigatório")]
        public string? Nome { get; set; }

        [Display(Name = "Ativo")]
        public string? IsAtivo { get; set; }

        [Display(Name = "Em Atividade")]
        public string? IsAtividade { get; set; }

        [Display(Name = "Data Hora Cadastro")]
        public DateTime? DataHoraCadastro { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório")]
        public long ClienteId { get; set; }


    }
}
