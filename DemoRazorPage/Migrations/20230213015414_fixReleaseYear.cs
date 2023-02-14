using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoRazorPage.Migrations
{
    public partial class fixReleaseYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "releaseYear",
                table: "Cars",
                newName: "ReleaseYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "Cars",
                newName: "releaseYear");
        }
    }
}
