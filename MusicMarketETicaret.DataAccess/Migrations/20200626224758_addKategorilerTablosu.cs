using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicMarketETicaret.DataAccess.Migrations
{
    public partial class addKategorilerTablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Makale");

            migrationBuilder.DropColumn(
                name: "KategoryTest",
                table: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KategoryTest",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Makale",
                columns: table => new
                {
                    MakaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakaleAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makale", x => x.MakaleId);
                });
        }
    }
}
