using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class AdicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999998,
                column: "ConcurrencyStamp",
                value: "d0396f7d-3e08-4d2f-bf4c-535ba5fde9f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999999,
                column: "ConcurrencyStamp",
                value: "17b29882-ef80-4d8c-b438-f9d213613a2a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b82f756a-58dc-45a5-8bd8-48b59cb141c3", "AQAAAAEAACcQAAAAEMqZG+xJpV/MnzAf7Yyis6C8GHM+CHzCy4HGdiiKeSxW2kVMQsGIXxrh9rsBrpsliQ==", "772d3cea-3d64-46a5-be9d-76dcf94cf690" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999998,
                column: "ConcurrencyStamp",
                value: "55b39767-e7cf-4ca5-9119-d876023d9a4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999999,
                column: "ConcurrencyStamp",
                value: "f31b3e1f-fb78-42cd-820c-897c9b5cb30f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74a3f111-da4c-4b87-903d-297508c7dd7d", "AQAAAAEAACcQAAAAEK/w40VIl99XvZcgK2rn/r7BkqdQdcpX+p82/MBhtOv3p41F02xu+2jW1ihS4Uj08g==", "898fc3e4-749c-4169-9a18-bdf2a3ae9373" });
        }
    }
}
