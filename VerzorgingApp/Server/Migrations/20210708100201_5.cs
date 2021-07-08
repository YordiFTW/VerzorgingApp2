using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerzorgingApp.Server.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CategoryColor", "EndTime", "StartTime", "Subject" },
                values: new object[] { 1, "#1aaa55", new DateTime(2020, 1, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "Explosion of Betelgeuse Star" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
