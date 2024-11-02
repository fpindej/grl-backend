using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GRL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Circuits",
                columns: new[] { "Id", "Country", "Location" },
                values: new object[,]
                {
                    { 1, "Bahrain", "Sakhir" },
                    { 2, "United States", "Las Vegas" },
                    { 3, "Australia", "Melbourne" },
                    { 4, "Portugal", "Algarve" },
                    { 5, "United States", "Miami" },
                    { 6, "Canada", "Montreal" },
                    { 7, "Italy", "Imola" },
                    { 8, "Spain", "Barcelona" },
                    { 9, "Austria", "Spielberg" },
                    { 10, "Great Britain", "Silverstone" },
                    { 11, "Hungary", "Mogyoród" },
                    { 12, "Belgium", "Spa-Francorchamps" },
                    { 13, "Netherlands", "Zandvoort" },
                    { 14, "Italy", "Monza" },
                    { 15, "Mexico", "Mexico City" },
                    { 16, "Singapore", "Marina Bay" },
                    { 17, "United States", "Austin" },
                    { 18, "Brazil", "São Paulo" },
                    { 19, "Qatar", "Lusail" },
                    { 20, "Abu Dhabi", "Yas Marina" },
                    { 21, "Japan", "Suzuka" },
                    { 22, "Monaco", "Monte Carlo" },
                    { 23, "China", "Shanghai" },
                    { 24, "Saudi Arabia", "Jeddah" },
                    { 25, "Azerbaijan", "Baku" }
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rookie" },
                    { 2, "Junior" },
                    { 3, "Talent" },
                    { 4, "Academy" },
                    { 5, "Main" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "LeagueId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "2024/25" },
                    { 2, 2, "2024/25" },
                    { 3, 3, "2024/25" },
                    { 4, 4, "2024/25" },
                    { 5, 5, "2024/25" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "CircuitId", "Date", "Round", "SeasonId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1 },
                    { 2, 2, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), 2, 1 },
                    { 3, 3, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), 3, 1 },
                    { 4, 4, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), 4, 1 },
                    { 5, 5, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), 5, 1 },
                    { 6, 6, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), 6, 1 },
                    { 7, 7, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Utc), 7, 1 },
                    { 8, 8, new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Utc), 8, 1 },
                    { 9, 9, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), 9, 1 },
                    { 10, 10, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), 10, 1 },
                    { 11, 11, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), 11, 1 },
                    { 12, 12, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), 12, 1 },
                    { 13, 13, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), 13, 1 },
                    { 14, 14, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), 14, 1 },
                    { 15, 15, new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Utc), 15, 1 },
                    { 16, 16, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), 16, 1 },
                    { 17, 17, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Utc), 17, 1 },
                    { 18, 18, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc), 18, 1 },
                    { 19, 19, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), 19, 1 },
                    { 20, 20, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), 20, 1 },
                    { 21, 1, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2 },
                    { 22, 21, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), 2, 2 },
                    { 23, 3, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), 3, 2 },
                    { 24, 4, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), 4, 2 },
                    { 25, 22, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), 5, 2 },
                    { 26, 6, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), 6, 2 },
                    { 27, 7, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), 7, 2 },
                    { 28, 8, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), 8, 2 },
                    { 29, 9, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), 9, 2 },
                    { 30, 10, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), 10, 2 },
                    { 31, 11, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), 11, 2 },
                    { 32, 12, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), 12, 2 },
                    { 33, 13, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), 13, 2 },
                    { 34, 14, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), 14, 2 },
                    { 35, 15, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), 15, 2 },
                    { 36, 16, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), 16, 2 },
                    { 37, 23, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17, 2 },
                    { 38, 18, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), 18, 2 },
                    { 39, 19, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), 19, 2 },
                    { 40, 20, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), 20, 2 },
                    { 41, 1, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3 },
                    { 42, 24, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 2, 3 },
                    { 43, 3, new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc), 3, 3 },
                    { 44, 21, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), 4, 3 },
                    { 45, 5, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), 5, 3 },
                    { 46, 6, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), 6, 3 },
                    { 47, 7, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), 7, 3 },
                    { 48, 8, new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc), 8, 3 },
                    { 49, 9, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), 9, 3 },
                    { 50, 10, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), 10, 3 },
                    { 51, 11, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11, 3 },
                    { 52, 12, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), 12, 3 },
                    { 53, 13, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), 13, 3 },
                    { 54, 14, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 14, 3 },
                    { 55, 25, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, 3 },
                    { 56, 16, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), 16, 3 },
                    { 57, 23, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), 17, 3 },
                    { 58, 18, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), 18, 3 },
                    { 59, 19, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), 19, 3 },
                    { 60, 20, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), 20, 3 },
                    { 61, 3, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4 },
                    { 62, 7, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), 2, 4 },
                    { 63, 17, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Utc), 3, 4 },
                    { 64, 15, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), 4, 4 },
                    { 65, 6, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), 5, 4 },
                    { 66, 8, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), 6, 4 },
                    { 67, 19, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), 7, 4 },
                    { 68, 9, new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), 8, 4 },
                    { 69, 10, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), 9, 4 },
                    { 70, 11, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), 10, 4 },
                    { 71, 12, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), 11, 4 },
                    { 72, 13, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), 12, 4 },
                    { 73, 14, new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), 13, 4 },
                    { 74, 16, new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), 14, 4 },
                    { 75, 20, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), 15, 4 },
                    { 76, 22, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), 16, 4 },
                    { 77, 21, new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), 17, 4 },
                    { 78, 1, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), 18, 4 },
                    { 79, 24, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), 19, 4 },
                    { 80, 18, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), 20, 4 },
                    { 81, 3, new DateTime(2024, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5 },
                    { 82, 7, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), 2, 5 },
                    { 83, 15, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), 3, 5 },
                    { 84, 6, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), 4, 5 },
                    { 85, 8, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), 5, 5 },
                    { 86, 19, new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), 6, 5 },
                    { 87, 20, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), 7, 5 },
                    { 88, 9, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), 8, 5 },
                    { 89, 10, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 9, 5 },
                    { 90, 11, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 10, 5 },
                    { 91, 12, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), 11, 5 },
                    { 92, 13, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), 12, 5 },
                    { 93, 14, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), 13, 5 },
                    { 94, 16, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), 14, 5 },
                    { 95, 17, new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), 15, 5 },
                    { 96, 23, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), 16, 5 },
                    { 97, 21, new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), 17, 5 },
                    { 98, 1, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), 18, 5 },
                    { 99, 24, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), 19, 5 },
                    { 100, 18, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), 20, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Circuits",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
