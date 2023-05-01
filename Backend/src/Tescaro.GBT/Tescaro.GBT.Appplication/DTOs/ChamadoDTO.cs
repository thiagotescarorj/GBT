namespace Tescaro.GBT.API.DTOs
{
    public class ChamadoDTO
    {
        public long Id { get; set; }

        public string? Numero { get; set; }

        public string? IsAtivo { get; set; }

        public string? DataHoraCadastro { get; set; }
        public string? DataRecebimento { get; set; }

        public string? DataPublicacao { get; set; }
        public string? DataEnvioHomologacao { get; set; }

        public string? Observacao { get; set; }

        public string? ScriptText { get; set; }
        public long ClienteId { get; set; }
        public long BancoDadosId { get; set; }
        public long DNSId { get; set; }
    }
}
