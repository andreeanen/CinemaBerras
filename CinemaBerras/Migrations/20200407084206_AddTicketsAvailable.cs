using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBerras.Migrations
{
    public partial class AddTicketsAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketsAvailable",
                table: "Displays",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsAvailable",
                table: "Displays");
        }
    }
}
