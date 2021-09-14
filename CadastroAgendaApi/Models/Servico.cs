using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroAgendaApi.Models
{
    public class Servico
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(180)]
        public string Descricao { get; set; }

        public double Valor { get; set; }

        public int minutos { get; set; }
    }
}
