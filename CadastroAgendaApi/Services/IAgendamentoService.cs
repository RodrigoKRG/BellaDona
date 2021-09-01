using CadastroAgendaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgendaApi.Services
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<Agendamento>> ObterAgendamentos();
        Task<Agendamento> ObterAgendamento(Guid id);
        Task<IEnumerable<Agendamento>> ObterAgendamentoPorCliente(string nome, bool atendimentoConcluido);
        Task CriarAgendamento(Agendamento pessoa);
        Task AtualizarAgendamento(Agendamento pessoa);
        Task DeletarAgendamento(Agendamento pessoa);
    }
}
