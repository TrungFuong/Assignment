using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Day1.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "JoinedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2158), "John Doe" },
                    { 2, 2, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2169), "Jane Doe" },
                    { 3, 1, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2170), "Alice" },
                    { 4, 3, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2171), "Bob" },
                    { 5, 2, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2172), "Charlie" },
                    { 6, 1, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2173), "David" },
                    { 7, 4, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2174), "Eve" },
                    { 8, 3, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2175), "Frank" },
                    { 9, 2, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2176), "Grace" },
                    { 10, 4, new DateTime(2024, 5, 14, 10, 44, 5, 477, DateTimeKind.Local).AddTicks(2177), "Helen" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Project 1" },
                    { 2, "Project 2" },
                    { 3, "Project 3" },
                    { 4, "Project 4" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "EmployeeId", "ProjectId", "Enable" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 4, 1, true },
                    { 8, 1, true },
                    { 3, 2, true },
                    { 9, 2, true },
                    { 5, 3, true },
                    { 6, 3, true },
                    { 2, 4, true },
                    { 7, 4, true },
                    { 10, 4, true }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "EmployeeId", "Salary" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 2, 2, 160 },
                    { 3, 3, 70 },
                    { 4, 4, 80 },
                    { 5, 5, 140 },
                    { 6, 6, 100 },
                    { 7, 7, 110 },
                    { 8, 8, 120 },
                    { 9, 9, 130 },
                    { 10, 10, 140 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
