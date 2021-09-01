using CadastroAgendaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgendaApi.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> ObterPessoas();
        Task<IEnumerable<Pessoa>> ObterClientes();
        Task<IEnumerable<Pessoa>> ObterFuncionarios();
        Task<Pessoa> ObterPessoa(Guid id);
        Task<IEnumerable<Pessoa>> ObterPessoaPorNome(string nome);
        Task CriarPessoa(Pessoa pessoa);
        Task AtualizarPessoa(Pessoa pessoa);
        Task DeletarPessoa(Pessoa pessoa);
        bool CpfJaCadastrado(string cpf);
    }
}
