using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoRutas.Backend.Repository.Migrations
{
    public partial class Nuevarutaagregada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ruta",
                columns: new[] { "id", "descripcion", "jurisdiccion", "longitud", "nombre", "numero" },
                values: new object[] { 2, "La Ruta 7 va de Buenos Aires hasta el límite con Chile, atravesando ciudades de importancia como Chacabuco, Junin, San Luis y Mendoza", "AR", 5194, "Ruta Nacional 7", 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ruta",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
