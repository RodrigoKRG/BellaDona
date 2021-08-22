using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroAgendaApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    CPFCNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
