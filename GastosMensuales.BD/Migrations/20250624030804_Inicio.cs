using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GastosMensuales.BD.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Totales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingreso_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Gasto_Fijo_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Gasto_Diario_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Ingreso_MenosGastosFijos_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SaldoActual = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Totales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GastosDiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TotalId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Acumulado = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosDiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastosDiarios_Totales_TotalId",
                        column: x => x.TotalId,
                        principalTable: "Totales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GastosDiarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastosFijos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TotalId = table.Column<int>(type: "int", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false),
                    FechaPagado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_A_Pagar = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosFijos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastosFijos_Totales_TotalId",
                        column: x => x.TotalId,
                        principalTable: "Totales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GastosFijos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Sobrante = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_Totales_TotalId",
                        column: x => x.TotalId,
                        principalTable: "Totales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingresos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_GastosDiarios_TotalId",
                table: "GastosDiarios",
                column: "TotalId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosDiarios_UsuarioId",
                table: "GastosDiarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosFijos_TotalId",
                table: "GastosFijos",
                column: "TotalId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosFijos_UsuarioId",
                table: "GastosFijos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosPorCategoria_GastoDiarioId",
                table: "GastosPorCategoria",
                column: "GastoDiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_TotalId",
                table: "Ingresos",
                column: "TotalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_UsuarioId",
                table: "Ingresos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GastosFijos");

            migrationBuilder.DropTable(
                name: "GastosPorCategoria");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "GastosDiarios");

            migrationBuilder.DropTable(
                name: "Totales");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
