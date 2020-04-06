using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBerras.Migrations
{
    public partial class ChangedDisplayModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TicketsSold",
                table: "Displays",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TicketsSold",
                table: "Displays",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
