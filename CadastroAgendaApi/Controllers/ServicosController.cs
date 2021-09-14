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
    public class ServicosController : ControllerBase
    {
        private IServicoService _servicoService;

        public ServicosController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Servico>>> GetServicos()
        {
            try
            {
                var servicos = await _servicoService.ObterServicos();
                return Ok(servicos);
            }
            catch (Exception)
            {
                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Serviços");
            }
        }

        [HttpGet("{id:Guid}", Name = "GetServico")]
        public async Task<ActionResult<Servico>> GetServico(Guid id)
        {
            try
            {
                var servico = await _servicoService.ObterServico(id);

                if (servico == null)
                    return NotFound($"Não existe Servico com o id = {id}");

                return Ok(servico);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Servico servico)
        {
            try
            {
                var servicos = await _servicoService.ObterServicos();
                if (servicos.Any(x => x.Descricao.Equals(servico.Descricao, StringComparison.OrdinalIgnoreCase)))
                    return BadRequest("Já possui um servico com a mesma descrição.");

                servico.Id = new Guid();
                await _servicoService.CriarServico(servico);
                return CreatedAtRoute(nameof(GetServico), new { id = servico.Id }, servico);
            }
            catch (Exception ex)
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] Servico servico)
        {
            try
            {
                if (servico.Id == id)
                {
                    await _servicoService.AtualizarServico(servico);
                    return Ok($"O servico de id = {id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var servico = await _servicoService.ObterServico(id);
                if (servico != null)
                {
                    await _servicoService.DeletarServico(servico);
                    return NoContent();
                }
                else
                {
                    return NotFound($"Servico com id = {id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
