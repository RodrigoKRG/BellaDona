using CadastroAgendaApi.Context;
using CadastroAgendaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgendaApi.Services
{
    public class PessoasService : IPessoaService
    {

        private readonly AppDbContext _context;

        public PessoasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> ObterPessoas()
        {
            try
            {
                return await _context.Pessoas.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Pessoa>> ObterClientes()
        {
            try
            {
                return await _context.Pessoas.Where(x => !x.Funcionario).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Pessoa>> ObterFuncionarios()
        {
            try
            {
                return await _context.Pessoas.Where(x => x.Funcionario).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Pessoa> ObterPessoa(Guid id)
        {
            try
            {
                return await _context.Pessoas.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Pessoa>> ObterPessoaPorNome(string nome)
        {
            try
            {
                IEnumerable<Pessoa> pessoas;
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    pessoas = await _context.Pessoas.Where(n => n.Nome.Contains(nome)).ToListAsync();
                } else
                {
                    pessoas = await ObterPessoas();
                }
                    
                return pessoas;
            }
            catch
            {
                throw;
            }
        }

        public async Task CriarPessoa(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task AtualizarPessoa(Pessoa pessoa)
        {
            try
            {
                _context.Entry(pessoa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeletarPessoa(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public bool CpfJaCadastrado(string cpf)
        {
            return _context.Pessoas.Any(x => x.CPFCNPJ == cpf);
        }
    }
}
