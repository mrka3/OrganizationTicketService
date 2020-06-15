using Microsoft.EntityFrameworkCore.Migrations;

namespace OTS.DataLayer.Migrations
{
    public partial class AddTicketCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketCost",
                table: "events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCost",
                table: "events");
        }
    }
}
