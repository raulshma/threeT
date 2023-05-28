using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThreeTee.Infrastructure.Persistence.Npgsql.Migrations
{
    /// <inheritdoc />
    public partial class initial_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BillingTypes",
                columns: new[] { "Id", "CreatedAt", "LastTouchedBy", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("39eaa6cd-ea93-40c8-a1fc-292eaa24bc10"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(7627), "System", "Other", null },
                    { new Guid("5b979829-86f8-474e-acf5-2544dca413af"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(7622), "System", "Upwork", null },
                    { new Guid("f2c53fc7-479d-4ef4-b5f8-714ba2202bc6"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(7626), "System", "Wired", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "CreatedAt", "LastTouchedBy", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3e0dae9c-e4b2-4e51-89a7-62e66f6c869a"), "QA", new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8544), "System", "Quality Analyst", null },
                    { new Guid("89d7f12f-a551-4db1-b616-76d9255ce520"), ".net", new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8542), "System", "Dotnet", null },
                    { new Guid("8f6f94db-6181-417e-b8f5-94f9f1cfbca3"), "BA", new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8546), "System", "Business Analyst", null }
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "Id", "CreatedAt", "LastTouchedBy", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("16d092d1-3ca9-4e79-a8bd-779c65c861c5"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8892), "System", "Junior Business Analyst", null },
                    { new Guid("847a84d3-e10c-4e8a-bdde-d4d3e714c0d9"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8891), "System", "Team Leader", null },
                    { new Guid("b25e25ee-5719-4291-be18-803bba6d277a"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8884), "System", "Software Engineer", null },
                    { new Guid("df9f5101-6b25-40c9-9458-2673c91b86a3"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8893), "System", "Business Analyst", null },
                    { new Guid("dfed32cb-d856-429e-8314-799e8aa509c6"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8895), "System", "Senior Business Analyst", null },
                    { new Guid("e1010c78-3a8f-40aa-bcbb-06af34da27bf"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8889), "System", "Senior Software Engineer", null },
                    { new Guid("fb47d5b0-c6b6-4be7-887d-5cc39fa7c1ca"), new DateTime(2023, 5, 28, 15, 42, 52, 85, DateTimeKind.Utc).AddTicks(8882), "System", "Junior Software Engineer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BillingTypes",
                keyColumn: "Id",
                keyValue: new Guid("39eaa6cd-ea93-40c8-a1fc-292eaa24bc10"));

            migrationBuilder.DeleteData(
                table: "BillingTypes",
                keyColumn: "Id",
                keyValue: new Guid("5b979829-86f8-474e-acf5-2544dca413af"));

            migrationBuilder.DeleteData(
                table: "BillingTypes",
                keyColumn: "Id",
                keyValue: new Guid("f2c53fc7-479d-4ef4-b5f8-714ba2202bc6"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("3e0dae9c-e4b2-4e51-89a7-62e66f6c869a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("89d7f12f-a551-4db1-b616-76d9255ce520"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8f6f94db-6181-417e-b8f5-94f9f1cfbca3"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("16d092d1-3ca9-4e79-a8bd-779c65c861c5"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("847a84d3-e10c-4e8a-bdde-d4d3e714c0d9"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("b25e25ee-5719-4291-be18-803bba6d277a"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("df9f5101-6b25-40c9-9458-2673c91b86a3"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("dfed32cb-d856-429e-8314-799e8aa509c6"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("e1010c78-3a8f-40aa-bcbb-06af34da27bf"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("fb47d5b0-c6b6-4be7-887d-5cc39fa7c1ca"));
        }
    }
}
