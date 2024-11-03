using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIGoldenData.Migrations
{
    /// <inheritdoc />
    public partial class GoldenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONSUMIDOR",
                columns: table => new
                {
                    IdConsumidor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sexo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSUMIDOR", x => x.IdConsumidor);
                });

            migrationBuilder.CreateTable(
                name: "FEEDBACK",
                columns: table => new
                {
                    IdFeedback = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Avaliacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConsumidorIdConsumidor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEEDBACK", x => x.IdFeedback);
                    table.ForeignKey(
                        name: "FK_FEEDBACK_CONSUMIDOR_ConsumidorIdConsumidor",
                        column: x => x.ConsumidorIdConsumidor,
                        principalTable: "CONSUMIDOR",
                        principalColumn: "IdConsumidor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICO_COMPRA",
                columns: table => new
                {
                    IdHistoricoCompra = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataCompra = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ValorCompra = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConsumidorIdConsumidor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICO_COMPRA", x => x.IdHistoricoCompra);
                    table.ForeignKey(
                        name: "FK_HISTORICO_COMPRA_CONSUMIDOR_ConsumidorIdConsumidor",
                        column: x => x.ConsumidorIdConsumidor,
                        principalTable: "CONSUMIDOR",
                        principalColumn: "IdConsumidor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INFO_CONSUMIDOR",
                columns: table => new
                {
                    IdInfoConsumidor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PreferenciaCompraCliente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PreferenciaAnuncio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MarcasEvitadas = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Hobbies = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AnunciosEvitados = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CompraOnline = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConsumidorIdConsumidor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INFO_CONSUMIDOR", x => x.IdInfoConsumidor);
                    table.ForeignKey(
                        name: "FK_INFO_CONSUMIDOR_CONSUMIDOR_ConsumidorIdConsumidor",
                        column: x => x.ConsumidorIdConsumidor,
                        principalTable: "CONSUMIDOR",
                        principalColumn: "IdConsumidor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAGAMENTO",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ValorPagamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MetodoPagamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StatusPagamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HistoricoCompraIdHistoricoCompra = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => x.IdPagamento);
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_HISTORICO_COMPRA_HistoricoCompraIdHistoricoCompra",
                        column: x => x.HistoricoCompraIdHistoricoCompra,
                        principalTable: "HISTORICO_COMPRA",
                        principalColumn: "IdHistoricoCompra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_ConsumidorIdConsumidor",
                table: "FEEDBACK",
                column: "ConsumidorIdConsumidor");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_COMPRA_ConsumidorIdConsumidor",
                table: "HISTORICO_COMPRA",
                column: "ConsumidorIdConsumidor");

            migrationBuilder.CreateIndex(
                name: "IX_INFO_CONSUMIDOR_ConsumidorIdConsumidor",
                table: "INFO_CONSUMIDOR",
                column: "ConsumidorIdConsumidor");

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_HistoricoCompraIdHistoricoCompra",
                table: "PAGAMENTO",
                column: "HistoricoCompraIdHistoricoCompra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FEEDBACK");

            migrationBuilder.DropTable(
                name: "INFO_CONSUMIDOR");

            migrationBuilder.DropTable(
                name: "PAGAMENTO");

            migrationBuilder.DropTable(
                name: "HISTORICO_COMPRA");

            migrationBuilder.DropTable(
                name: "CONSUMIDOR");
        }
    }
}
