using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchApi.Tracker.Migrations
{
    public partial class removerowversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Investigations");

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                table: "Investigations",
                type: "xid",
                nullable: false,
                defaultValue: 0u);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xmin",
                table: "Investigations");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Investigations",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
