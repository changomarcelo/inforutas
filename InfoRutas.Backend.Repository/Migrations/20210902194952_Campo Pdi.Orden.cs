using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoRutas.Backend.Repository.Migrations
{
    public partial class CampoPdiOrden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comentario_pdi_pdi_id",
                table: "comentario");

            migrationBuilder.DropForeignKey(
                name: "fk_comentario_tramo_tramo_id",
                table: "comentario");

            migrationBuilder.AddColumn<int>(
                name: "orden",
                table: "pdi",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "tramo",
                columns: new[] { "id", "fecha_informe", "informe", "nombre", "orden", "ruta_id" },
                values: new object[] { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta", "Mendoza - La Quiaca", 6, 2 });

            migrationBuilder.InsertData(
                table: "pdi",
                columns: new[] { "id", "categoria_id", "es_aporte", "fin", "inicio", "latitud", "longitud", "nombre", "orden", "tramo_id", "usuario_id" },
                values: new object[,]
                {
                    { 1, 1, false, false, true, 0m, 0m, "La Quiaca", 1, 9, 1 },
                    { 2, 1, false, true, false, 0m, 0m, "Rio Gallegos", 2, 9, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_comentario_pdi_pdi_id",
                table: "comentario",
                column: "pdi_id",
                principalTable: "pdi",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comentario_tramo_tramo_id",
                table: "comentario",
                column: "tramo_id",
                principalTable: "tramo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comentario_pdi_pdi_id",
                table: "comentario");

            migrationBuilder.DropForeignKey(
                name: "fk_comentario_tramo_tramo_id",
                table: "comentario");

            migrationBuilder.DeleteData(
                table: "pdi",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pdi",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tramo",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "orden",
                table: "pdi");

            migrationBuilder.AddForeignKey(
                name: "fk_comentario_pdi_pdi_id",
                table: "comentario",
                column: "pdi_id",
                principalTable: "pdi",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_comentario_tramo_tramo_id",
                table: "comentario",
                column: "tramo_id",
                principalTable: "tramo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
