using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatSport.Api.Migrations
{
    public partial class AddData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "CityId", "ClubId", "DateEnd", "DateStart", "Note", "OtherPlace", "SportId" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2021, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "", 1 },
                    { 2, 1, null, new DateTime(2021, 12, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "", 1 },
                    { 3, 1, null, new DateTime(2021, 12, 31, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), "", "", 1 },
                    { 4, 1, null, new DateTime(2021, 12, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), "", "", 1 },
                    { 5, 1, null, new DateTime(2022, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "", 1 },
                    { 6, 2, null, new DateTime(2021, 12, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), "", "", 1 },
                    { 7, 1, null, new DateTime(2021, 12, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "", "", 2 },
                    { 8, 2, null, new DateTime(2021, 12, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "", 2 },
                    { 9, 1, null, new DateTime(2021, 12, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "", 2 },
                    { 10, 3, null, new DateTime(2021, 12, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "", 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Assist", "MatchId", "Note", "Team", "UserId" },
                values: new object[,]
                {
                    { 1, true, 1, "", 1, 1 },
                    { 2, false, 1, "", 2, 2 },
                    { 3, true, 1, "", 1, 3 },
                    { 4, false, 2, "", 1, 1 },
                    { 5, false, 2, "", 1, 2 },
                    { 6, false, 2, "", 2, 3 },
                    { 7, false, 2, "", 2, 4 },
                    { 8, false, 3, "", 1, 3 },
                    { 9, false, 4, "", 1, 4 },
                    { 10, false, 4, "", 1, 4 },
                    { 11, false, 5, "", 1, 5 },
                    { 12, false, 6, "", 1, 5 },
                    { 13, false, 10, "", 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "MatchId", "Number", "Team", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 6 },
                    { 2, 1, 1, 2, 2 },
                    { 3, 1, 2, 1, 3 },
                    { 4, 1, 2, 2, 6 },
                    { 5, 1, 3, 1, 6 },
                    { 6, 1, 3, 2, 0 },
                    { 7, 2, 1, 1, 6 },
                    { 8, 2, 1, 2, 2 },
                    { 9, 2, 2, 1, 6 },
                    { 10, 2, 2, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "ScoreConfirmations",
                columns: new[] { "Id", "Confirmed", "PlayerId", "ScoreId" },
                values: new object[,]
                {
                    { 1, true, 1, 1 },
                    { 2, true, 1, 2 },
                    { 3, true, 1, 3 },
                    { 4, true, 1, 4 },
                    { 5, true, 1, 5 },
                    { 6, true, 1, 6 },
                    { 7, true, 3, 1 },
                    { 8, true, 3, 2 },
                    { 9, true, 3, 3 },
                    { 10, true, 3, 4 },
                    { 11, true, 3, 5 },
                    { 12, true, 3, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ScoreConfirmations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
