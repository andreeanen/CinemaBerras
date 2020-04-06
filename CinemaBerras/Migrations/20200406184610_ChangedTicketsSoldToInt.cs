using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBerras.Migrations
{
    public partial class ChangedTicketsSoldToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TicketsSold",
                table: "Displays",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TicketsSold",
                table: "Displays",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
