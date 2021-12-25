using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatSport.Api.Migrations
{
    public partial class changesequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Equipments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Equipments",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Equipments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "OtherPlace",
                value: "pistas de carranque");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Note", "OtherPlace" },
                values: new object[] { "Test note 1", "Urb. lolo" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3,
                column: "OtherPlace",
                value: "pistas la mosca");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Note", "OtherPlace" },
                values: new object[] { "Test note fff", "Urb. las gaviotas" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5,
                column: "OtherPlace",
                value: "Urb. ");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Note", "OtherPlace" },
                values: new object[] { "Test note afgds", "pistas de gimnasio turu" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 7,
                column: "OtherPlace",
                value: "Playa de huelin");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 8,
                column: "OtherPlace",
                value: "Sacaba");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Note", "OtherPlace" },
                values: new object[] { "Test note voley 1", "Parque badajo" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 10,
                column: "OtherPlace",
                value: "pista voley carranque");

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Assist", "MatchId", "Note", "Team", "UserId" },
                values: new object[,]
                {
                    { 14, false, 9, "", 1, 5 },
                    { 15, false, 9, "", 2, 1 },
                    { 16, false, 9, "", 2, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Equipments",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "OtherPlace",
                value: "");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Note", "OtherPlace" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3,
                column: "OtherPlace",
                value: "");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Note", "OtherPlace" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5,
                column: "OtherPlace",
                value: "");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Note", "OtherPlace" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 7,
                column: "OtherPlace",
                value: "");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 8,
                column: "OtherPlace",
                value: "");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Note", "OtherPlace" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 10,
                column: "OtherPlace",
                value: "");
        }
    }
}
