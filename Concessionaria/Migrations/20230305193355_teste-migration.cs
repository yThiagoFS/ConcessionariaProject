using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concessionaria.Migrations
{
    public partial class testemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Marcas",
                newName: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarcaId",
                table: "Marcas",
                newName: "Id");
        }
    }
}
