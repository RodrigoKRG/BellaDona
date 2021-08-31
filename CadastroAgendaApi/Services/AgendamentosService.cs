using CadastroAgendaApi.Context;
using CadastroAgendaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgendaApi.Services
{
    public class AgendamentosService : IAgendamentoService
    {

        private readonly AppDbContext _context;

        public AgendamentosService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Agendamento>> ObterAgendamentos()
        {
            try
            {
                return await _context.Agendamentos.Where(x => !x.Cliente.Funcionario && !x.AtendimentoConcluido).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
     
        public async Task<Agendamento> ObterAgendamento(Guid id)
        {

            try
            {
                return await _context.Agendamentos.FindAsync(id);
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<Agendamento>> ObterAgendamentoPorCliente(string nome)
        {
            try
            {
                IEnumerable<Agendamento> agendamentos;
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    agendamentos = await _context.Agendamentos.Where(n => n.Cliente.Nome.Contains(nome) && !n.Cliente.Funcionario).ToListAsync();
                }
                else
                {
                    agendamentos = await ObterAgendamentos();
                }

                return agendamentos;
            }
            catch
            {
                throw;
            }
        }

        public Task CriarAgendamento(Agendamento pessoa)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAgendamento(Agendamento pessoa)
        {
            throw new NotImplementedException();
        }

        public Task DeletarAgendamento(Agendamento pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
