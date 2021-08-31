using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroAgendaApi.Migrations
{
    public partial class AddColumnFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Funcionario",
                table: "Pessoas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Funcionario",
                table: "Pessoas");
        }
    }
}
