using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatSport.Api.Migrations
{
    public partial class _20211214_AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 2, 1, "Granada" },
                    { 3, 1, "Barcelona" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Login",
                value: "admin");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastName", "Login", "Name", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { 3, "latrusca", "user1", "Amparo", "098f6bcd4621d373cade4e832627b4f6", "User", true },
                    { 4, "Perez", "user4", "Florencio", "098f6bcd4621d373cade4e832627b4f6", "User", true },
                    { 5, "Pelaez", "user5", "Maria", "098f6bcd4621d373cade4e832627b4f6", "User", true },
                    { 6, "Gomez", "test", "Juan", "098f6bcd4621d373cade4e832627b4f6", "User", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CityId",
                table: "Matches",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Cities_CityId",
                table: "Matches",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Cities_CityId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CityId",
                table: "Matches");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Login",
                value: "test");
        }
    }
}
