using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroAgendaApi.Models
{
    public class Pessoa
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(180)]
        public string Nome { get; set; }

        [Required]
        [StringLength(18)]
        public string CPFCNPJ { get; set; }

        public bool Funcionario { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string DataNascimentoFormat
        {
            get
            {
                return DataNascimento.HasValue ? DataNascimento.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(180)]
        public string Endereco { get; set; }

        [StringLength(60)]
        public string Numero { get; set; }

        [StringLength(500)]
        public string Complemento { get; set; }

        [StringLength(200)]
        public string Bairro { get; set; }

        [StringLength(80)]
        public string Cidade { get; set; }

        [StringLength(80)]
        public string Estado { get; set; }

        [Phone]
        [StringLength(15)]
        public string Telefone { get; set; }

        [Phone]
        [StringLength(15)]
        public string Celular { get; set; }

        public string CelularFormat
        {
            get
            {
                return long.Parse(Celular).ToString(@"(00) 00000-0000");
            }
        }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

    }
}
