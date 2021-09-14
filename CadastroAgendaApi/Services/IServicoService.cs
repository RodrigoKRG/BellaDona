using CadastroAgendaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgendaApi.Services
{
    public interface IServicoService
    {
        Task<IEnumerable<Servico>> ObterServicos();
        Task<Servico> ObterServico(Guid id);
        Task CriarServico(Servico servico);
        Task AtualizarServico(Servico servico);
        Task DeletarServico(Servico servico);
    }
}
