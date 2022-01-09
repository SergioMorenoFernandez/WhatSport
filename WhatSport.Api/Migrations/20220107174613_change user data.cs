using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatSport.Api.Migrations
{
    public partial class changeuserdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreConfirmations_Players_PlayerId",
                table: "ScoreConfirmations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreConfirmations_Scores_ScoreId",
                table: "ScoreConfirmations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "admin@uoc.edu", "08458ec8927fa3f9c176bcf1fffc671c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "08458ec8927fa3f9c176bcf1fffc671c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "08458ec8927fa3f9c176bcf1fffc671c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "c4882f5eefc3c13ecc6b7e1954e9ea85");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "c4882f5eefc3c13ecc6b7e1954e9ea85");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LastName", "Login", "Name", "Password" },
                values: new object[] { "Moreno", "test@uoc.edu", "Sergio", "08458ec8927fa3f9c176bcf1fffc671c" });

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreConfirmations_Players_PlayerId",
                table: "ScoreConfirmations",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreConfirmations_Scores_ScoreId",
                table: "ScoreConfirmations",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreConfirmations_Players_PlayerId",
                table: "ScoreConfirmations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreConfirmations_Scores_ScoreId",
                table: "ScoreConfirmations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "admin", "098f6bcd4621d373cade4e832627b4f6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "098f6bcd4621d373cade4e832627b4f6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "098f6bcd4621d373cade4e832627b4f6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "098f6bcd4621d373cade4e832627b4f6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "098f6bcd4621d373cade4e832627b4f6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LastName", "Login", "Name", "Password" },
                values: new object[] { "Gomez", "test", "Juan", "098f6bcd4621d373cade4e832627b4f6" });

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreConfirmations_Players_PlayerId",
                table: "ScoreConfirmations",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreConfirmations_Scores_ScoreId",
                table: "ScoreConfirmations",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
