using Microsoft.AspNetCore.Mvc;
using Tescaro.GBT.API.DTOs;
using Tescaro.GBT.Appplication.Interfaces;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Repository;

namespace Tescaro.GBT.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class BancoDadosController : ControllerBase
    {
        private readonly IBancoDadosService _bancoDadosService;
        private readonly IClienteService _clienteService;
        public BancoDadosController(
            IBancoDadosService bancoDadosService,
            IClienteService clienteService)
        {
            _bancoDadosService = bancoDadosService;
            _clienteService = clienteService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var bancoDadosList = await _bancoDadosService.GetTodosBancoDados();
                if (bancoDadosList == null)
                {
                    return NotFound("Nenhum Banco de Dados encontrado.");
                }
                else
                {
                    return Ok(bancoDadosList);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Banco de Dados. Erro: {ex.Message}");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var bancoDados = await _bancoDadosService.GetBancoDadosById(id);
                if (bancoDados == null)
                {
                    return NotFound($"O Banco de Dados de ID: {id} n�o encontrado.");
                }
                else
                {
                    return Ok(bancoDados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar BancoDados de ID: {id}. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var bancoDados = await _bancoDadosService.GetTodosBancoDadosByNome(nome);
                if (bancoDados == null)
                {
                    return NotFound($"O Banco de Dados de nome: {nome} n�o encontrado.");
                }
                else
                {
                    return Ok(bancoDados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Banco de Dados de nome: {nome}. Erro: {ex.Message}");
            }
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetByCliente(long clienteId)
        {
            try
            {
                var cliente = await _clienteService.GetClienteById(clienteId);
                if (cliente == null) 
                {
                    return NotFound($"Cliente de ID: {clienteId} n�o encontrado");
                }
                var bancoDados = await _bancoDadosService.GetTodosBancoDadosByCliente(clienteId);
                if (bancoDados == null)
                {
                    return NotFound($"O BancoDados vinculado ao cliente: {cliente.Nome} n�o encontrado.");
                }
                else
                {
                    return Ok(bancoDados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar BancoDados vinculado ao cliente: {clienteId}. Erro: {ex.Message}");
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(BancoDadosDTO bancoDados)
        {
            try
            {
                var BancoDados = await _bancoDadosService.AdicionarBancoDados(bancoDados);
                if (BancoDados == null)
                {
                    return NotFound($"Erro ao tentar adcionar Banco de Dados.");
                }                
                else
                {
                    return Ok(bancoDados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adcionar Banco de Dados. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id)
        {
            try
            {

                var bancoDados = await _bancoDadosService.GetBancoDadosById(id);
                if (bancoDados == null)
                {
                    return NotFound($"Erro ao tentar adcionar Banco de Dados.");
                }
                else
                {
                    await _bancoDadosService.AtualizarBancoDados(id, bancoDados);

                    return Ok(bancoDados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar Banco de Dados ID:{id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (await _bancoDadosService.ExcluirBancoDados(id))
                {
                    return Ok($"Banco de Dados ID:{id} deletado");
                }
                else
                {
                    return BadRequest($"Banco de Dados ID:{id} n�o deletado");

                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar excluir Banco de Dados ID:{id}. Erro: {ex.Message}");
            }
        }

    }

}
