using CadastroAgendaApi.Models;
using CadastroAgendaApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private IAgendamentoService _agendamentoService;
        private IPessoaService _pessoaService;

        public AgendamentosController(IAgendamentoService agendamentoService, IPessoaService pessoaService)
        {
            _agendamentoService = agendamentoService;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Agendamento>>> GetAgendamentos()
        {
            try
            {
                var agendamentos = await _agendamentoService.ObterAgendamentos();
                return Ok(agendamentos);
            }
            catch (Exception)
            {
                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Agendamentos");
            }
        }

        [HttpGet("AgendamentosPorCliente")]
        public async Task<ActionResult<IAsyncEnumerable<Agendamento>>> GetAgendamentosByCliente([FromQuery] string nome)
        {
            try
            {
                var agendamentos = await _agendamentoService.ObterAgendamentoPorCliente(nome);

                if (agendamentos == null)
                    return NotFound($"Não existem Agentamentos com o critétio {nome}");

                return Ok(agendamentos);
            }
            catch
            {

                return BadRequest("Request inválido");
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //    "Erro ao obter Pessoas");
            }
        }

        [HttpGet("{id:Guid}", Name = "GetAgentamento")]
        public async Task<ActionResult<Pessoa>> GetAgentamento(Guid id)
        {
            try
            {
                var agendamento = await _agendamentoService.ObterAgendamento(id);

                if (agendamento == null)
                    return NotFound($"Não existe Agendamento com o id = {id}");

                return Ok(agendamento);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Agendamento agendamento)
        {
            try
            {
                var clientes = await _pessoaService.ObterClientes();
                if (clientes.FirstOrDefault(x => x.Id == agendamento.ClienteId) == null)
                    return BadRequest("Cliente não cadastrado.");

                var funcionarios = await _pessoaService.ObterFuncionarios();
                if (agendamento.FuncionarioId.HasValue && funcionarios.FirstOrDefault(x => x.Id == agendamento.FuncionarioId) == null)
                    return BadRequest("funcionario não cadastrado.");

                agendamento.Id = new Guid();
                await _agendamentoService.CriarAgendamento(agendamento);
                return CreatedAtRoute(nameof(GetAgentamento), new { id = agendamento.Id }, agendamento);
            }
            catch (Exception ex)
            {
                return BadRequest("Request inválido");
            }
        }

    }
}
