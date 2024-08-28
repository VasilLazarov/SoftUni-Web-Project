using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class OrderPaymentAndAddressFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Order_OrderId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Order_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_OrderId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Order address identifier");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Order payment identifier");

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

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                table: "Order",
                column: "PaymentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Addresses_AddressId",
                table: "Order",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payments_PaymentId",
                table: "Order",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Addresses_AddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payments_PaymentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_AddressId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Payment order identifier");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Payment order identifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "5ca4c336-7222-46d2-9c34-3d6c9f409128");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "1309a8c9-7e20-4422-83cd-82ef38585017");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "3a66af98-0e73-4c85-a35a-b402e1fd153b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbdaa156-90af-4048-a1df-117b77e3580c", "AQAAAAEAACcQAAAAELBrKUR3bz6aw7eX5LARXns29KT9j4pXhedKHyfBoQr4b5cb+lsup2eqLHEmPpWSlg==", "4a83e132-09c7-4847-946a-902eab5f3e2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7eece765-5c2a-46cf-b87e-61a97256b62d", "AQAAAAEAACcQAAAAEDlFyOBcYlLWdVozNC3XdPcnhUolc5j0r6f4LDNQzuEoH5lUn0Wcg+4ck1or5FJHaA==", "d5b9484b-36e0-45be-a2c8-e0d3a58b7605" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5754c3b-2b41-41b6-8c68-107dbf96ba88", "AQAAAAEAACcQAAAAEEHip7z6uCAew2VIFrdJcgxhKdv2xXbUWHqqGGJyVZhn+u+YqoLhO+PinDPhuZTMGg==", "b72a73e9-b62b-4aa3-8561-89fec311117c" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 16, 14, 14, 36, 482, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 31, 14, 14, 36, 482, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 3, 20, 14, 14, 36, 482, DateTimeKind.Local).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedOn",
                value: new DateTime(2024, 2, 16, 14, 14, 36, 482, DateTimeKind.Local).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedOn",
                value: new DateTime(2023, 9, 16, 14, 14, 36, 482, DateTimeKind.Local).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 16, 7, 14, 36, 482, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OrderId",
                table: "Addresses",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Order_OrderId",
                table: "Addresses",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Order_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
