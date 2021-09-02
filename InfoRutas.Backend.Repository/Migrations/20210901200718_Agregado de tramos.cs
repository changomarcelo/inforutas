using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoRutas.Backend.Repository.Migrations
{
    public partial class Agregadodetramos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tramo",
                columns: new[] { "id", "fecha_informe", "informe", "nombre", "orden", "ruta_id" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autovía", "Buenos Aires - Junin", 1, 2 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta en buen estado", "Junin - San Luis", 2, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autovía en su mayor parte", "San Luis - Mendoza", 4, 2 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta", "Rio Gallegos - El Calafate", 1, 1 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta", "El Calafate - Bariloche", 2, 1 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta", "Bariloche - San Martín de los Andes", 3, 2 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta", "San Martín de los Andes - Malargüe", 4, 2 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta", "Malargüe - Mendoza", 5, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 8);
        }
    }
}
