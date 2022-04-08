using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class UsuarioRegular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999999,
                column: "ConcurrencyStamp",
                value: "f31b3e1f-fb78-42cd-820c-897c9b5cb30f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 999999998, "55b39767-e7cf-4ca5-9119-d876023d9a4d", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74a3f111-da4c-4b87-903d-297508c7dd7d", "AQAAAAEAACcQAAAAEK/w40VIl99XvZcgK2rn/r7BkqdQdcpX+p82/MBhtOv3p41F02xu+2jW1ihS4Uj08g==", "898fc3e4-749c-4169-9a18-bdf2a3ae9373" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999999,
                column: "ConcurrencyStamp",
                value: "aabd6094-a236-458f-97e1-ffc1ad3c6422");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b7d7837-d582-486b-b5ab-f7cd362d3826", "AQAAAAEAACcQAAAAEF7vnDoUWH1uRZ51TZ0nURk155SmSaEKH3aJ+r7TVcb80mZ1sWYfvaow6FMSd+7RPw==", "0ad207e3-8067-4ba5-9bf2-600193400ba4" });
        }
    }
}
