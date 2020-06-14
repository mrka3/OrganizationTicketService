using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTS.DataLayer.Migrations
{
    public partial class AddPersonFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TicketCount",
                table: "events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "events");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "events");

            migrationBuilder.DropColumn(
                name: "TicketCount",
                table: "events");
        }
    }
}
