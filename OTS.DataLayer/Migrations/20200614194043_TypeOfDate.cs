using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTS.DataLayer.Migrations
{
    public partial class TypeOfDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IssueDate",
                table: "events",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "events",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
