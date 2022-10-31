using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.Entity.Migrations
{
    public partial class initialdbv002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 23, 22, 48, 988, DateTimeKind.Local).AddTicks(1290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 15, 12, 39, 871, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "Email", "Password", "RegisterDate", "UserName" },
                values: new object[] { "fadaeian@Gmail.com", "32231ebf7e0f3491886dbf837b09b9eb", new DateTime(2022, 10, 31, 23, 22, 48, 988, DateTimeKind.Local).AddTicks(1804), "Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "FirstName", "LastName", "Password", "RegisterDate", "UserName" },
                values: new object[] { 1, "", "user@Gmail.com", "testuser", "testuser", "682e93a42e5acf606ce5d583f6cd7bf1", new DateTime(2022, 10, 31, 23, 22, 48, 988, DateTimeKind.Local).AddTicks(1840), "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 15, 12, 39, 871, DateTimeKind.Local).AddTicks(1674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 31, 23, 22, 48, 988, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "Email", "Password", "RegisterDate", "UserName" },
                values: new object[] { "fadaeian.mohammad@Gmail.com", "0226bf22762ed7864084ea87d02ed547", new DateTime(2022, 10, 28, 15, 12, 39, 871, DateTimeKind.Local).AddTicks(2779), "Administrator" });
        }
    }
}
