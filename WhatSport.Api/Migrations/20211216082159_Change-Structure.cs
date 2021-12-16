using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatSport.Api.Migrations
{
    public partial class ChangeStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberPlayers",
                table: "Sports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumberPlayers",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "NumberPlayers" },
                values: new object[] { "Voley-Playa", 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberPlayers",
                table: "Sports");

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Futbol");
        }
    }
}
