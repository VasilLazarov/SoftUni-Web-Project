using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class EditNewsToMakeTeamIdRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Teams_TeamId",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of team the news is about",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Identifier of team the news is about");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "615105d5-f6ca-407c-9350-99d4e5ff7192");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "5e7cb106-66e7-4a2b-8d1d-fbdf008cfa83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "60924455-07cc-4196-9050-717de0cb8614");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec9b4ffb-bb99-4a05-ba4b-f2e2a914a4e2", "AQAAAAEAACcQAAAAEIIHj9joyltKnOWAFJefwiQXpEEeKxNDnJFthPAwg9jDe7h4xuNYTpuHtL1N1PYwCg==", "94df5635-660a-40f9-8a1d-6a20565236d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c9c4f24-8db9-4383-bed1-b929339c40c6", "AQAAAAEAACcQAAAAEDTsFqkY0eRpIbSC2nbY+TT7wvhaf1y3+7lNPFP+uicYWnhhICWqFqh9VGjcNjnHJw==", "4608a25f-547e-4fca-8a83-ca398aa00f8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ae79ab0-ea81-4d8f-b48f-f5c39cf16177", "AQAAAAEAACcQAAAAEEuX1DkNdUP7B0u3R/alHxTnW21aWkPLu8ur9jBmbdh8/xLLbpvcAO2rElepy96z/Q==", "1ebb1573-441e-4e82-a335-83cc3cba7f1a" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 14, 18, 42, 43, 713, DateTimeKind.Local).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 29, 18, 42, 43, 713, DateTimeKind.Local).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 3, 18, 18, 42, 43, 713, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedOn",
                value: new DateTime(2024, 2, 14, 18, 42, 43, 713, DateTimeKind.Local).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedOn",
                value: new DateTime(2023, 9, 14, 18, 42, 43, 713, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 14, 11, 42, 43, 713, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.AddForeignKey(
                name: "FK_News_Teams_TeamId",
                table: "News",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Teams_TeamId",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "News",
                type: "int",
                nullable: true,
                comment: "Identifier of team the news is about",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of team the news is about");

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

            migrationBuilder.AddForeignKey(
                name: "FK_News_Teams_TeamId",
                table: "News",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
