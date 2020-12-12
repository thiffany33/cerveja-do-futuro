using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerveja.Do.Futuro.Infra.Migrations
{
    public partial class CriacaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoProduto",
                table: "Produtos",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoProduto",
                table: "Produtos");
        }
    }
}
