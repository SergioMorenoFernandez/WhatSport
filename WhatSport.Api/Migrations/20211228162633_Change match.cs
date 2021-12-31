using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatSport.Api.Migrations
{
    public partial class Changematch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "TimeInMinutes",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "MatchId", "PlayerId" },
                values: new object[,]
                {
                    { 1, "Red Voley", 9, null },
                    { 2, "Pelota", 9, 15 }
                });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OtherPlace", "TimeInMinutes" },
                values: new object[] { "Pistas de carranque", 60 });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeInMinutes",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OtherPlace", "TimeInMinutes" },
                values: new object[] { "Pistas la mosca", 90 });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CityId", "TimeInMinutes" },
                values: new object[] { null, 90 });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OtherPlace", "TimeInMinutes" },
                values: new object[] { "Urb. el Almendro", 90 });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "OtherPlace", "TimeInMinutes" },
                values: new object[] { "Pistas de gimnasio turu", 120 });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 7,
                column: "TimeInMinutes",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 8,
                column: "TimeInMinutes",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 9,
                column: "TimeInMinutes",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OtherPlace", "TimeInMinutes" },
                values: new object[] { "Pista voley carranque", 60 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TimeInMinutes",
                table: "Matches");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateEnd", "OtherPlace" },
                values: new object[] { new DateTime(2021, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "pistas de carranque" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEnd",
                value: new DateTime(2021, 12, 11, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateEnd", "OtherPlace" },
                values: new object[] { new DateTime(2021, 12, 31, 18, 0, 0, 0, DateTimeKind.Unspecified), "pistas la mosca" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CityId", "DateEnd" },
                values: new object[] { 1, new DateTime(2021, 12, 21, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateEnd", "OtherPlace" },
                values: new object[] { new DateTime(2022, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), "Urb. " });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateEnd", "OtherPlace" },
                values: new object[] { new DateTime(2021, 12, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), "pistas de gimnasio turu" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateEnd",
                value: new DateTime(2021, 12, 17, 17, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateEnd",
                value: new DateTime(2021, 12, 16, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateEnd",
                value: new DateTime(2021, 12, 31, 14, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateEnd", "OtherPlace" },
                values: new object[] { new DateTime(2021, 12, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), "pista voley carranque" });
        }
    }
}
