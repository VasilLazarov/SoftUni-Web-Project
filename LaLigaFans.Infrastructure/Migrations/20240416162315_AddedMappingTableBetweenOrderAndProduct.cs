using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class AddedMappingTableBetweenOrderAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "OrderProduct is a mapping table entity class");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "0713acd6-d3c9-4a89-9244-c439387d5089");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "f0f619b4-92fc-49c3-b3ee-8c55c7535e2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "2cb44d88-cf37-45bf-91d0-d6b696848a80");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32131503-db63-4209-9c82-6d1906a56c45", "AQAAAAEAACcQAAAAEMYM+9agHhVem2/bfzf9wpuo1ghgd7mA5yccZK4SM4oCnL+IaAEehw6snyiOy9WorQ==", "2729fcca-0ec0-4a76-b957-ed09ef3779af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7845b9c9-635e-47e4-b6fd-d5ce967e6e94", "AQAAAAEAACcQAAAAEIZtKx5oMzgkMGlY7uhR9dTjmrjYbUPKYTiBOBZ3jIy2FGgs8AIBtlAkx6Py03H2Mw==", "415b0b00-8e1a-4df9-9e59-c77e101e3240" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "660a9712-b72b-47e8-ac1e-394214bacaba", "AQAAAAEAACcQAAAAEDCqMEIs/kq0wlt4d6hX3XiQtqFbUlGjVUy0GvJlRoa/wqEEXaJu9fmc4tLcZs4iYQ==", "64d9ccbb-f3d7-4636-9e9f-4440fd6f4d3c" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 16, 19, 23, 14, 608, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 31, 19, 23, 14, 608, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 3, 20, 19, 23, 14, 608, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedOn",
                value: new DateTime(2024, 2, 16, 19, 23, 14, 608, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedOn",
                value: new DateTime(2023, 9, 16, 19, 23, 14, 608, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 16, 12, 23, 14, 608, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_OrderId",
                table: "OrdersProducts",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "87417f80-996e-43b8-a418-9330582b8561");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "1f935250-f8f7-4617-ad43-c853b866c3f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "32a95e3e-a02d-4a1e-9700-d680c02fde8c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4a775fa-9b46-4cf8-a83b-f598590fa1ac", "AQAAAAEAACcQAAAAEGGD1tpHg1nBapvIIeP6sQbjw4Te0/nSZOREOQEboV+CXeEHylauD4hEJ2D9VCmsKA==", "a0b3e445-4f26-4f9a-a7a9-c52043635448" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4718f4c-df37-4926-bdac-fc208771cadb", "AQAAAAEAACcQAAAAEFVXfH72cl9trxMM8ntgtRrkaGhD8YNOi025jC5sLb5KKfflkbU50lWXALOCb6JsZw==", "7466bf07-33e2-45b4-87ef-d78800d0cf39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc5120b8-f26d-4390-a401-0853fae1a6f9", "AQAAAAEAACcQAAAAEEm1AO88JDyk7RtVM/TwHLdRUnqeUY8cNrKMvCPiUweWRENx3FvfJDAyHIhH6Sv7tg==", "78570bd6-54bf-4953-a005-5ea47a0f6428" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 16, 19, 12, 9, 365, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 31, 19, 12, 9, 365, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 3, 20, 19, 12, 9, 365, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedOn",
                value: new DateTime(2024, 2, 16, 19, 12, 9, 365, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedOn",
                value: new DateTime(2023, 9, 16, 19, 12, 9, 365, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 16, 12, 12, 9, 365, DateTimeKind.Local).AddTicks(7189));
        }
    }
}
