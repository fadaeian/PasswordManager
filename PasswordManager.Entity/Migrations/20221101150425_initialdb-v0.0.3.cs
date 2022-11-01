using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.Entity.Migrations
{
    public partial class initialdbv003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 34, 25, 259, DateTimeKind.Local).AddTicks(3488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 31, 23, 22, 48, 988, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    PasswordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    SiteURL = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 1, 18, 34, 25, 259, DateTimeKind.Local).AddTicks(4758)),
                    ModifiedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.PasswordId);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: -1,
                column: "RegisterDate",
                value: new DateTime(2022, 11, 1, 18, 34, 25, 259, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2022, 11, 1, 18, 34, 25, 259, DateTimeKind.Local).AddTicks(4018));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 23, 22, 48, 988, DateTimeKind.Local).AddTicks(1290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 34, 25, 259, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: -1,
                column: "RegisterDate",
                value: new DateTime(2022, 10, 31, 23, 22, 48, 988, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2022, 10, 31, 23, 22, 48, 988, DateTimeKind.Local).AddTicks(1840));
        }
    }
}
