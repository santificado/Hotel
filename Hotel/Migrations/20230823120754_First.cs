using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HOSPEDE",
                columns: table => new
                {
                    HospedeID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HOSPEDE", x => x.HospedeID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PAGAMENTO",
                columns: table => new
                {
                    PagamentoID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataPagamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PAGAMENTO", x => x.PagamentoID);
                });

            migrationBuilder.CreateTable(
                name: "TB_TP_QUARTOS",
                columns: table => new
                {
                    TipoQuartoID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TP_QUARTOS", x => x.TipoQuartoID);
                });

            migrationBuilder.CreateTable(
                name: "TB_RESERVA",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataEntrada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PagamentoID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RESERVA", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_TB_RESERVA_TB_PAGAMENTO_PagamentoID",
                        column: x => x.PagamentoID,
                        principalTable: "TB_PAGAMENTO",
                        principalColumn: "PagamentoID");
                });

            migrationBuilder.CreateTable(
                name: "HospedeReserva",
                columns: table => new
                {
                    HospedesHospedeID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReservasReservaID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospedeReserva", x => new { x.HospedesHospedeID, x.ReservasReservaID });
                    table.ForeignKey(
                        name: "FK_HospedeReserva_TB_HOSPEDE_HospedesHospedeID",
                        column: x => x.HospedesHospedeID,
                        principalTable: "TB_HOSPEDE",
                        principalColumn: "HospedeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospedeReserva_TB_RESERVA_ReservasReservaID",
                        column: x => x.ReservasReservaID,
                        principalTable: "TB_RESERVA",
                        principalColumn: "ReservaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_QUARTOS",
                columns: table => new
                {
                    QuartoID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NumeroQuarto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PrecoPorNoite = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ReservaID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_QUARTOS", x => x.QuartoID);
                    table.ForeignKey(
                        name: "FK_TB_QUARTOS_TB_RESERVA_ReservaID",
                        column: x => x.ReservaID,
                        principalTable: "TB_RESERVA",
                        principalColumn: "ReservaID");
                });

            migrationBuilder.CreateTable(
                name: "QuartoTipoQuarto",
                columns: table => new
                {
                    QuartosQuartoID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoQuartosTipoQuartoID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuartoTipoQuarto", x => new { x.QuartosQuartoID, x.TipoQuartosTipoQuartoID });
                    table.ForeignKey(
                        name: "FK_QuartoTipoQuarto_TB_QUARTOS_QuartosQuartoID",
                        column: x => x.QuartosQuartoID,
                        principalTable: "TB_QUARTOS",
                        principalColumn: "QuartoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuartoTipoQuarto_TB_TP_QUARTOS_TipoQuartosTipoQuartoID",
                        column: x => x.TipoQuartosTipoQuartoID,
                        principalTable: "TB_TP_QUARTOS",
                        principalColumn: "TipoQuartoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospedeReserva_ReservasReservaID",
                table: "HospedeReserva",
                column: "ReservasReservaID");

            migrationBuilder.CreateIndex(
                name: "IX_QuartoTipoQuarto_TipoQuartosTipoQuartoID",
                table: "QuartoTipoQuarto",
                column: "TipoQuartosTipoQuartoID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_QUARTOS_ReservaID",
                table: "TB_QUARTOS",
                column: "ReservaID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESERVA_PagamentoID",
                table: "TB_RESERVA",
                column: "PagamentoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospedeReserva");

            migrationBuilder.DropTable(
                name: "QuartoTipoQuarto");

            migrationBuilder.DropTable(
                name: "TB_HOSPEDE");

            migrationBuilder.DropTable(
                name: "TB_QUARTOS");

            migrationBuilder.DropTable(
                name: "TB_TP_QUARTOS");

            migrationBuilder.DropTable(
                name: "TB_RESERVA");

            migrationBuilder.DropTable(
                name: "TB_PAGAMENTO");
        }
    }
}
