using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDeDatos.Migrations
{
    /// <inheritdoc />
    public partial class agregandoKeyCabaña : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "tipos",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costoPorHuesped = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "cabañas",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoNombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tieneJacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    estaHabilitada = table.Column<bool>(type: "bit", nullable: false),
                    cantMax = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabañas", x => x.Nombre);
                    table.ForeignKey(
                        name: "FK_cabañas_tipos_TipoNombre",
                        column: x => x.TipoNombre,
                        principalTable: "tipos",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabañaNombre = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mantenimientos_cabañas_CabañaNombre",
                        column: x => x.CabañaNombre,
                        principalTable: "cabañas",
                        principalColumn: "Nombre");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cabañas_TipoNombre",
                table: "cabañas",
                column: "TipoNombre");

            migrationBuilder.CreateIndex(
                name: "IX_mantenimientos_CabañaNombre",
                table: "mantenimientos",
                column: "CabañaNombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "mantenimientos");

            migrationBuilder.DropTable(
                name: "cabañas");

            migrationBuilder.DropTable(
                name: "tipos");
        }
    }
}
