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
    public class PessoasController : ControllerBase
    {
        private IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Pessoa>>> GetPessoas()
        {
            try
            {
                var pessoas = await _pessoaService.ObterPessoa();
                return Ok(pessoas);
            }
            catch (Exception)
            {
                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Pessoas");
            }
        }

        [HttpGet("PessoasPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Pessoa>>> GetPessoasByName([FromQuery] string nome)
        {
            try
            {
                var pessoas = await _pessoaService.ObterPessoaPorNome(nome);

                if (pessoas == null)
                    return NotFound($"Não existem Pessoas com o critétio {nome}");

                return Ok(pessoas);
            }
            catch
            {

                return BadRequest("Request inválido");
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //    "Erro ao obter Pessoas");
            }
        }

        [HttpGet("{id:Guid}", Name = "GetPessoa")]
        public async Task<ActionResult<Pessoa>> GetPessoa(Guid id)
        {
            try
            {
                var pessoa = await _pessoaService.ObterPessoa(id);

                if (pessoa == null)
                    return NotFound($"Não existe Pessoa com o id = {id}");

                return Ok(pessoa);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Pessoa pessoa)
        {
            try
            {          
                
                if(_pessoaService.CpfJaCadastrado(pessoa.CPFCNPJ))
                    return BadRequest("Ops, já existe um cadastro com o CPF informado.");

                pessoa.Id = new Guid();
                await _pessoaService.CriarPessoa(pessoa);
                return CreatedAtRoute(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa.Id == id)
                {
                    await _pessoaService.AtualizarPessoa(pessoa);
                    return Ok($"Pessoa com id = {id} foi atualizado com sucesso");
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
                var Pessoa = await _pessoaService.ObterPessoa(id);
                if (Pessoa != null)
                {
                    await _pessoaService.DeletarPessoa(Pessoa);
                    return Ok($"Pessoa com id = {id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Pessoa com id = {id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

    }
}
