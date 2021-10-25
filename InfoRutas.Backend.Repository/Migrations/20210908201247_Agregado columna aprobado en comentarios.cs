using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoRutas.Backend.Repository.Migrations
{
    public partial class Agregadocolumnaaprobadoencomentarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "aprobado",
                table: "pdi",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "aprobado",
                table: "comentario",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "pdi",
                keyColumn: "id",
                keyValue: 1,
                column: "aprobado",
                value: true);

            migrationBuilder.UpdateData(
                table: "pdi",
                keyColumn: "id",
                keyValue: 2,
                column: "aprobado",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aprobado",
                table: "pdi");

            migrationBuilder.DropColumn(
                name: "aprobado",
                table: "comentario");
        }
    }
}
