using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class RemoveColumsFromNewsAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisLikes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisLikes",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "News");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "c1d64ac9-7df2-4577-8130-98071e227829");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "42c32e37-d0b4-432e-8e1e-f9877d5dbffa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "5c13326d-e42b-4fff-9e08-fbdbac5da603");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93d374a5-5999-4175-a28c-6ba783cb92c8", "AQAAAAEAACcQAAAAELzJpDuOm0RBNA1PoIg65jgXl1uxVueHnKUtPJhWzu+AEBUGSvpZIWuOQo67aRohYA==", "b4f1c83e-5710-49f9-91cd-4b3c51c5a9a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8b342a4-5edf-45f1-8349-d0daec95e42b", "AQAAAAEAACcQAAAAEP4uiLZabDcCq1tuv1AkhgodzgVHB655OKBxcurzuKnLN40UGJoTfB7LSTJfQ/NANw==", "2829bb0e-2b38-4c95-b976-83eb7c65105c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f374611d-dfcb-4d06-bbe8-f91e3e28e368", "AQAAAAEAACcQAAAAEFHXjvBwY3BdL/Te5H8Rz9LbM3iKJPFUWS9Fn6WKcXnxjSTu9gQJms+62M/1GO8s3g==", "87244d04-ddf5-41b6-8f23-1223b6fa2405" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 14, 8, 54, 34, 164, DateTimeKind.Local).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 29, 8, 54, 34, 164, DateTimeKind.Local).AddTicks(2731));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 3, 18, 8, 54, 34, 164, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedOn",
                value: new DateTime(2024, 2, 14, 8, 54, 34, 164, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedOn",
                value: new DateTime(2023, 9, 14, 8, 54, 34, 164, DateTimeKind.Local).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 14, 1, 54, 34, 164, DateTimeKind.Local).AddTicks(2740));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisLikes",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Product dislikes");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Product likes");

            migrationBuilder.AddColumn<int>(
                name: "DisLikes",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "News dislikes");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "News likes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "609a660a-6ceb-4c81-bdd9-d18d0c00a8ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "407a3b76-4170-41a8-9888-d8d984ae690d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "0551e31c-2494-4c1e-ac17-f526a1ac2ce3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bf5f9ea-d705-4bca-8ff9-e5944e415cf2", "AQAAAAEAACcQAAAAEN7PxeuWIIPoaiwber5qPbBB7R2bsixUAAN97avgIYqz4LACIEHdpLYpsshSv/p0Xg==", "10b82cea-3036-474a-a01d-7b977e8fe665" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "671a6713-cedd-42cb-84dd-83c2da221a4f", "AQAAAAEAACcQAAAAEMbpeGMsCxUd+oYeE+PwLLBdP1EWEQ0hXNOQHGxMBw10wQ79G3UXoGmMc/o36msaDw==", "5f2a8b7c-d087-4961-afb1-90de146128e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "739618c9-3614-4fc8-a10c-5eebcc1b7e14", "AQAAAAEAACcQAAAAENq0nP2i1VzfJNIQ1VFCfNJvgwd8A/TOjc1jKW32+S9Aewv+EqD6kpefhCjai8sH0A==", "e56ab5a4-43f0-4b65-b987-1a257df58644" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 12, 16, 13, 18, 428, DateTimeKind.Local).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 27, 16, 13, 18, 428, DateTimeKind.Local).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 3, 16, 16, 13, 18, 428, DateTimeKind.Local).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedOn",
                value: new DateTime(2024, 2, 12, 16, 13, 18, 428, DateTimeKind.Local).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedOn",
                value: new DateTime(2023, 9, 12, 16, 13, 18, 428, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 12, 9, 13, 18, 428, DateTimeKind.Local).AddTicks(9725));
        }
    }
}
