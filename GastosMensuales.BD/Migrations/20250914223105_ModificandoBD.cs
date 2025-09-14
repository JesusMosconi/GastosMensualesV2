using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GastosMensuales.BD.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GastosDiarios_Totales_TotalId",
                table: "GastosDiarios");

            migrationBuilder.DropForeignKey(
                name: "FK_GastosFijos_Totales_TotalId",
                table: "GastosFijos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Totales_TotalId",
                table: "Ingresos");

            migrationBuilder.DropTable(
                name: "GastosPorCategoria");

            migrationBuilder.DropTable(
                name: "Totales");

            migrationBuilder.DropIndex(
                name: "IX_Ingresos_TotalId",
                table: "Ingresos");

            migrationBuilder.DropIndex(
                name: "IX_GastosFijos_TotalId",
                table: "GastosFijos");

            migrationBuilder.DropIndex(
                name: "IX_GastosDiarios_TotalId",
                table: "GastosDiarios");

            migrationBuilder.DropColumn(
                name: "TotalId",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "TotalId",
                table: "GastosFijos");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "GastosDiarios");

            migrationBuilder.DropColumn(
                name: "TotalId",
                table: "GastosDiarios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPagado",
                table: "GastosFijos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "GastosDiarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalId",
                table: "Ingresos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FechaPagado",
                table: "GastosFijos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "TotalId",
                table: "GastosFijos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "GastosDiarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Mes",
                table: "GastosDiarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalId",
                table: "GastosDiarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GastosPorCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GastoDiarioId = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Porcentaje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosPorCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastosPorCategoria_GastosDiarios_GastoDiarioId",
                        column: x => x.GastoDiarioId,
                        principalTable: "GastosDiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Totales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gasto_Diario_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Gasto_Fijo_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Ingreso_MenosGastosFijos_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Ingreso_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SaldoActual = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Totales", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_TotalId",
                table: "Ingresos",
                column: "TotalId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosFijos_TotalId",
                table: "GastosFijos",
                column: "TotalId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosDiarios_TotalId",
                table: "GastosDiarios",
                column: "TotalId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosPorCategoria_GastoDiarioId",
                table: "GastosPorCategoria",
                column: "GastoDiarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_GastosDiarios_Totales_TotalId",
                table: "GastosDiarios",
                column: "TotalId",
                principalTable: "Totales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GastosFijos_Totales_TotalId",
                table: "GastosFijos",
                column: "TotalId",
                principalTable: "Totales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Totales_TotalId",
                table: "Ingresos",
                column: "TotalId",
                principalTable: "Totales",
                principalColumn: "Id");
        }
    }
}
