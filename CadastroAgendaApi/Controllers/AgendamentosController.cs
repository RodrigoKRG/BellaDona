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

        public AgendamentosController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
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
    }
}
