using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoRazorPage.Migrations
{
    public partial class fixQuantityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Carts",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Carts",
                newName: "quantity");
        }
    }
}
