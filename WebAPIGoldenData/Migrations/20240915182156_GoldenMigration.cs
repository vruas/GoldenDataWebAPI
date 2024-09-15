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

            migrationBuilder.CreateIndex(
                name: "IX_INFO_CONSUMIDOR_ConsumidorIdConsumidor",
                table: "INFO_CONSUMIDOR",
                column: "ConsumidorIdConsumidor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INFO_CONSUMIDOR");

            migrationBuilder.DropTable(
                name: "CONSUMIDOR");
        }
    }
}
