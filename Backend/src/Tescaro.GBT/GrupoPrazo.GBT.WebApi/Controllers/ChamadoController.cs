using Microsoft.AspNetCore.Mvc;
using Tescaro.GBT.API.DTOs;
using Tescaro.GBT.Appplication.Interfaces;

namespace Tescaro.GBT.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;
        private readonly IClienteService _clienteService;
        private readonly IDNSService _dnsService;
        private readonly IBancoDadosService _bancoDados;
        public ChamadoController(
            IChamadoService chamadoService,
            IClienteService clienteService,
            IDNSService dnsService,
            IBancoDadosService bancoDados)
        {
            _chamadoService = chamadoService;
            _clienteService = clienteService;
            _dnsService = dnsService;
            _bancoDados = bancoDados;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoDTO>>> GetAll()
        {
            try
            {
                var chamados = await _chamadoService.GetTodosChamados();
                if (chamados == null)
                {
                    return NotFound("Nenhum Chamado encontrado.");
                }
                else
                {
                    return Ok(chamados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Chamados. Erro: {ex.Message}");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var chamado = await _chamadoService.GetChamadoById(id);
                if (chamado == null)
                {
                    return NotFound($"O Chamado de ID: {id} n�o encontrado.");
                }
                else
                {
                    return Ok(chamado);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Chamado de ID: {id}. Erro: {ex.Message}");
            }
        }

        [HttpGet("chamado/{numero}")]
        public async Task<IActionResult> GetByNumero(string numero)
        {
            try
            {
                var chamado = await _chamadoService.GetTodosChamadosByNumero(numero);
                if (chamado == null)
                {
                    return NotFound($"O Chamado de n�mero: {numero} n�o encontrado.");
                }
                else
                {
                    return Ok(chamado);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Chamado de n�mero: {numero}. Erro: {ex.Message}");
            }
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByCliente(long clienteId)
        {
            try
            {
                var cliente = await _clienteService.GetClienteById(clienteId);
                if (cliente == null) 
                {
                    return NotFound($"Cliente de ID: {clienteId} n�o encontrado");
                }
                var chamado = await _chamadoService.GetTodosChamadosByCliente(clienteId);
                if (chamado == null)
                {
                    return NotFound($"O Chamado vinculado ao cliente: {cliente.Nome} n�o encontrado.");
                }
                else
                {
                    return Ok(chamado);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Chamado vinculado ao cliente: {clienteId}. Erro: {ex.Message}");
            }
        }

        [HttpGet("dns/{dnsId}")]
        public async Task<IActionResult> GetByDNS(long dnsId)
        {
            try
            {
                var dns = await _dnsService.GetDNSById(dnsId);
                if (dns == null)
                {
                    return NotFound($"DNS de ID: {dnsId} n�o encontrado");
                }
                var chamado = await _chamadoService.GetTodosChamadosByCliente(dnsId);
                if (chamado == null)
                {
                    return NotFound($"O Chamado vinculado ao dns: {dns.Nome} n�o encontrado.");
                }
                else
                {
                    return Ok(chamado);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Chamado vinculado ao dns: {dnsId}. Erro: {ex.Message}");
            }
        }

        [HttpGet("bancoDados/{bancoDadosId}")]
        public async Task<IActionResult> GetByBancoDados(long bancoDadosId)
        {
            try
            {
                var bancoDados = await _bancoDados.GetBancoDadosById(bancoDadosId);
                if (bancoDados == null)
                {
                    return NotFound($"Banco de Dados de ID: {bancoDadosId} n�o encontrado");
                }
                var chamado = await _chamadoService.GetTodosChamadosByCliente(bancoDadosId);
                if (chamado == null)
                {
                    return NotFound($"O Chamado de vinculado ao banco de dados: {bancoDados.Nome} n�o encontrado.");
                }
                else
                {
                    return Ok(chamado);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Chamado de n�mero: {bancoDadosId  }. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ChamadoDTO chamado)
        {
            try
            {
                var Chamado = await _chamadoService.AdicionarChamado(chamado);
                if (Chamado == null)
                {
                    return NotFound($"Erro ao tentar adcionar chamado.");
                }                
                else
                {
                    return Ok(chamado);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adcionar Chamado. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, ChamadoDTO model)
        {
            try
            {

                var chamado = await _chamadoService.GetChamadoById(id);
                if (chamado == null)
                {
                    return NotFound($"Erro ao tentar adcionar chamado.");
                }
                else
                {
                    await _chamadoService.AtualizarChamado(id, model);

                    return Ok(chamado);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar Chamado ID:{id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (await _chamadoService.ExcluirChamado(id))
                {
                    return Ok($"Chamado ID:{id} deletado");
                }
                else
                {
                    return BadRequest($"Chamado ID:{id} n�o deletado");

                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar excluir Chamado ID:{id}. Erro: {ex.Message}");
            }
        }

    }

}
