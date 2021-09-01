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
                return await _context.Agendamentos
                    .Include(c => c.Cliente)
                    .Include(f => f.Funcionario)
                    .Where(x => !x.Cliente.Funcionario && !x.AtendimentoConcluido).ToListAsync();
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

        public async Task<IEnumerable<Agendamento>> ObterAgendamentoPorCliente(string nome, bool atendimentoConcluido)
        {
            try
            {
                IEnumerable<Agendamento> agendamentos;
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    agendamentos = await _context.Agendamentos
                        .Include(c => c.Cliente)
                        .Include(f => f.Funcionario)
                        .Where(n => n.Cliente.Nome.Contains(nome) && !n.Cliente.Funcionario && !n.AtendimentoConcluido).ToListAsync();
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

        public async Task CriarAgendamento(Agendamento agendamento)
        {
            try
            {
                _context.Agendamentos.Add(agendamento);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task AtualizarAgendamento(Agendamento agendamento)
        {
            try
            {
                _context.Entry(agendamento).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeletarAgendamento(Agendamento agendamento)
        {
            try
            {
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
