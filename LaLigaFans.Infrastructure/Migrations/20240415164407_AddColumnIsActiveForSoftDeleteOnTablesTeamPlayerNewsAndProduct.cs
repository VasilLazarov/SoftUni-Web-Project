using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class AddColumnIsActiveForSoftDeleteOnTablesTeamPlayerNewsAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Team is active or not active(soft deleted)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Product is active or not active(soft deleted)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Player is active or not active(soft deleted)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "News is active or not active(soft deleted)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "e3139c5c-c171-4b0c-84be-30296b093191");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "4411a386-ac55-4c0b-bc27-6d0e5a4714f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "c91b579c-ffcf-44fa-9cb3-efee89114504");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a929bb03-dca8-4047-b1d5-b685e72dc657", "AQAAAAEAACcQAAAAEIS/QHEdgwRW/qnvacYkNu7H19AdmTNLLztIhtel9IMQxCtl6WgwMc6XV8wmI/q1HQ==", "69f890a4-83da-4ef8-b9e5-0008a739023a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4aa9a9fb-b679-4c1a-9d76-43ffba897965", "AQAAAAEAACcQAAAAEGr4tIOMpmVaUrN9Nhyea/jT/zGLp86O9L2AkJb51CZH7X+YvYJQpnyiEwaW1ZNutQ==", "1343a428-3604-437f-bb19-e2e3c3813f93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49de1459-ca08-4752-8ef5-f5cc061efcfd", "AQAAAAEAACcQAAAAEONTVmXa9+SSEAJ9T7reroSGlrvOtAo6CHLaeshQPwOogrQh8KqktcAPlPH7fjt7gQ==", "3f95278f-bd99-456a-b710-10e5afacfd1f" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 15, 19, 44, 7, 273, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 30, 19, 44, 7, 273, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 3, 19, 19, 44, 7, 273, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedOn",
                value: new DateTime(2024, 2, 15, 19, 44, 7, 273, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedOn",
                value: new DateTime(2023, 9, 15, 19, 44, 7, 273, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 15, 12, 44, 7, 273, DateTimeKind.Local).AddTicks(4846));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "News");

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
        }
    }
}
