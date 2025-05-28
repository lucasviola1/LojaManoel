using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaManoel.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dimensoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    altura = table.Column<int>(type: "int", nullable: false),
                    largura = table.Column<int>(type: "int", nullable: false),
                    comprimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    caixa_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dimensoesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Caixa_Dimensoes_dimensoesid",
                        column: x => x.dimensoesid,
                        principalTable: "Dimensoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caixa_dimensoesid",
                table: "Caixa",
                column: "dimensoesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caixa");

            migrationBuilder.DropTable(
                name: "Dimensoes");
        }
    }
}
