using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroAgendaApi.Models
{
    public class Agendamento
    {
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }

        public Guid? FuncionarioId { get; set; }

        public DateTime Horario { get; set; }

        public bool AtendimentoConcluido { get; set; }

        public virtual Pessoa Cliente { get; set; }

        public virtual Pessoa Funcionario { get; set; }
    }
}
