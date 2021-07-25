using Microsoft.EntityFrameworkCore.Migrations;

namespace AEKWeb.Migrations
{
    public partial class Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Event",
                table: "Events",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "Event");
        }
    }
}
