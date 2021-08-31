using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InfoRutas.Backend.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ruta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    jurisdiccion = table.Column<string>(type: "text", nullable: true),
                    longitud = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ruta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    nivel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tramo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    orden = table.Column<int>(type: "integer", nullable: false),
                    informe = table.Column<string>(type: "text", nullable: true),
                    fecha_informe = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ruta_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tramo", x => x.id);
                    table.ForeignKey(
                        name: "fk_tramo_users_ruta_id",
                        column: x => x.ruta_id,
                        principalTable: "ruta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pdi",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    latitud = table.Column<decimal>(type: "numeric", nullable: false),
                    longitud = table.Column<decimal>(type: "numeric", nullable: false),
                    es_aporte = table.Column<bool>(type: "boolean", nullable: false),
                    inicio = table.Column<bool>(type: "boolean", nullable: false),
                    fin = table.Column<bool>(type: "boolean", nullable: false),
                    categoria_id = table.Column<int>(type: "integer", nullable: false),
                    tramo_id = table.Column<int>(type: "integer", nullable: false),
                    usuario_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pdi", x => x.id);
                    table.ForeignKey(
                        name: "fk_pdi_categoria_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pdi_tramo_tramo_id",
                        column: x => x.tramo_id,
                        principalTable: "tramo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pdi_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comentario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    texto = table.Column<string>(type: "text", nullable: true),
                    usuario_id = table.Column<int>(type: "integer", nullable: false),
                    pdi_id = table.Column<int>(type: "integer", nullable: true),
                    tramo_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comentario", x => x.id);
                    table.ForeignKey(
                        name: "fk_comentario_pdi_pdi_id",
                        column: x => x.pdi_id,
                        principalTable: "pdi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comentario_tramo_tramo_id",
                        column: x => x.tramo_id,
                        principalTable: "tramo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comentario_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Localidades" },
                    { 2, "Estaciones de Servicio" },
                    { 3, "Paradores" },
                    { 4, "Áreas de descanso" },
                    { 5, "Restaurantes" },
                    { 6, "Miradores" },
                    { 7, "Sitios turísticos" },
                    { 8, "Baños" },
                    { 9, "Alojamientos" },
                    { 10, "Peajes" },
                    { 11, "Aportes" }
                });

            migrationBuilder.InsertData(
                table: "ruta",
                columns: new[] { "id", "descripcion", "jurisdiccion", "longitud", "nombre", "numero" },
                values: new object[] { 1, "La Ruta Nacional Nº 40 «Libertador General Don José de San Martín»1 es una carretera de Argentina cuyo recorrido se extiende desde el cabo Vírgenes, Santa Cruz hasta el límite con Bolivia en la ciudad de La Quiaca, en Jujuy.", "AR", 5194, "Ruta Nacional 40", 40 });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "activo", "email", "nivel", "nombre", "password_hash" },
                values: new object[] { 1, true, "marce@centraldev.com.ar", 1, "Marce", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92" });

            migrationBuilder.CreateIndex(
                name: "ix_comentario_pdi_id",
                table: "comentario",
                column: "pdi_id");

            migrationBuilder.CreateIndex(
                name: "ix_comentario_tramo_id",
                table: "comentario",
                column: "tramo_id");

            migrationBuilder.CreateIndex(
                name: "ix_comentario_usuario_id",
                table: "comentario",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_pdi_categoria_id",
                table: "pdi",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "ix_pdi_tramo_id",
                table: "pdi",
                column: "tramo_id");

            migrationBuilder.CreateIndex(
                name: "ix_pdi_usuario_id",
                table: "pdi",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_ruta_numero_jurisdiccion",
                table: "ruta",
                columns: new[] { "numero", "jurisdiccion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tramo_ruta_id",
                table: "tramo",
                column: "ruta_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comentario");

            migrationBuilder.DropTable(
                name: "pdi");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "tramo");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "ruta");
        }
    }
}
