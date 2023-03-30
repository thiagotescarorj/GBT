using Microsoft.AspNetCore.Identity;
using System.Buffers.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;

namespace Tescaro.GBT.WebAPI.Models
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
        
    }
}
