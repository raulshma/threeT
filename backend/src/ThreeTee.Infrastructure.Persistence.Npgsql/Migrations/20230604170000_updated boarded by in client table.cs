using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThreeTee.Infrastructure.Persistence.Npgsql.Migrations
{
    /// <inheritdoc />
    public partial class updatedboardedbyinclienttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients");

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

            migrationBuilder.DropColumn(
                name: "BoardedBy",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Clients",
                newName: "BoardedById");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                newName: "IX_Clients_BoardedById");

            migrationBuilder.InsertData(
                table: "BillingTypes",
                columns: new[] { "Id", "CreatedAt", "LastTouchedBy", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2fded05b-635f-4889-b263-6ec1922d95fb"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Wired", null },
                    { new Guid("6e6027f9-f685-47c8-a1fe-43c32a620014"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Other", null },
                    { new Guid("dc53bb89-bb11-449b-96c2-5c7ac4d4bcd2"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Upwork", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "CreatedAt", "LastTouchedBy", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("143b0f1f-beb6-4e6b-a26b-1dd307dd6306"), "BA", new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Business Analyst", null },
                    { new Guid("53691279-ef76-4054-8c2f-e28f6028f16d"), "QA", new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Quality Analyst", null },
                    { new Guid("e5c7e9ec-d1c2-441d-a4dc-253cdf766707"), ".net", new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Dotnet", null }
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "Id", "CreatedAt", "LastTouchedBy", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5ecc925e-f3d8-4152-8d0a-440e3bb03b17"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Junior Business Analyst", null },
                    { new Guid("6955c5b0-dadf-41bf-b616-28cf1dea7129"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Software Engineer", null },
                    { new Guid("6db98ad2-61e3-45f9-93ea-fe8af7fdd44b"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Team Leader", null },
                    { new Guid("7ef46b11-e30f-4311-a358-e9d95994ae67"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Business Analyst", null },
                    { new Guid("a0b3df08-e63a-4914-a576-6287a940b035"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Junior Software Engineer", null },
                    { new Guid("d39fe1e8-fc62-405e-8c04-5539f141dbb2"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Senior Business Analyst", null },
                    { new Guid("dfc436f4-d875-42fc-bb43-569d82dda847"), new DateTime(2023, 6, 4, 22, 25, 44, 501, DateTimeKind.Utc), "System", "Senior Software Engineer", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_BoardedById",
                table: "Clients",
                column: "BoardedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_BoardedById",
                table: "Clients");

            migrationBuilder.DeleteData(
                table: "BillingTypes",
                keyColumn: "Id",
                keyValue: new Guid("2fded05b-635f-4889-b263-6ec1922d95fb"));

            migrationBuilder.DeleteData(
                table: "BillingTypes",
                keyColumn: "Id",
                keyValue: new Guid("6e6027f9-f685-47c8-a1fe-43c32a620014"));

            migrationBuilder.DeleteData(
                table: "BillingTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc53bb89-bb11-449b-96c2-5c7ac4d4bcd2"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("143b0f1f-beb6-4e6b-a26b-1dd307dd6306"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("53691279-ef76-4054-8c2f-e28f6028f16d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e5c7e9ec-d1c2-441d-a4dc-253cdf766707"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("5ecc925e-f3d8-4152-8d0a-440e3bb03b17"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("6955c5b0-dadf-41bf-b616-28cf1dea7129"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("6db98ad2-61e3-45f9-93ea-fe8af7fdd44b"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("7ef46b11-e30f-4311-a358-e9d95994ae67"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("a0b3df08-e63a-4914-a576-6287a940b035"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("d39fe1e8-fc62-405e-8c04-5539f141dbb2"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: new Guid("dfc436f4-d875-42fc-bb43-569d82dda847"));

            migrationBuilder.RenameColumn(
                name: "BoardedById",
                table: "Clients",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_BoardedById",
                table: "Clients",
                newName: "IX_Clients_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "BoardedBy",
                table: "Clients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
