using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diretor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Diretor", "Nome", "Resumo" },
                values: new object[] { 1, "Hayato Date", "Naruto", "A história segue Naruto Uzumaki, um jovem ninja que busca reconhecimento e sonha em se tornar Hokage, o líder de sua vila." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");
        }
    }
}
