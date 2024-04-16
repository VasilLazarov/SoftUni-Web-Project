using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class AddIsActiveToCommentAndMakeCommentTitleMaxLengthBigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Comment title",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Comment title");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Comment is active or not active(soft deleted)");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Comment title",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Comment title");

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
    }
}
