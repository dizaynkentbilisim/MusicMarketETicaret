using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicMarketETicaret.DataAccess.Migrations
{
    public partial class teset0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KategoryTest",
                table: "Category",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategoryTest",
                table: "Category");
        }
    }
}
