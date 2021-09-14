using CadastroAgendaApi.Context;
using CadastroAgendaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgendaApi.Services
{
    public class ServicosService : IServicoService
    {

        private readonly AppDbContext _context;

        public ServicosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servico>> ObterServicos()
        {
            try
            {
                return await _context.Servicos.ToListAsync();  
            }
            catch
            {
                throw;
            }
        }
     
        public async Task<Servico> ObterServico(Guid id)
        {

            try
            {
                return await _context.Servicos.FindAsync(id);
            }
            catch
            {
                throw;
            }

        }

        public async Task CriarServico(Servico servico)
        {
            try
            {
                _context.Servicos.Add(servico);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task AtualizarServico(Servico servico)
        {
            try
            {
                _context.Entry(servico).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeletarServico(Servico servico)
        {
            try
            {
                _context.Servicos.Remove(servico);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
