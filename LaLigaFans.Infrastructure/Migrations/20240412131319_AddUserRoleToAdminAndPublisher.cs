using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class AddUserRoleToAdminAndPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f9725b78-b6af-40c1-90d4-f77de178c1fd", "176d92cc-bdaf-4569-94b8-fa377f980d89" },
                    { "f9725b78-b6af-40c1-90d4-f77de178c1fd", "1dcd54f5-dc66-4540-8cf9-d44658029bfd" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9725b78-b6af-40c1-90d4-f77de178c1fd", "176d92cc-bdaf-4569-94b8-fa377f980d89" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9725b78-b6af-40c1-90d4-f77de178c1fd", "1dcd54f5-dc66-4540-8cf9-d44658029bfd" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "8f87513f-80aa-418f-9554-f93faadf65d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "6ac9b2cc-693b-4257-906f-81967d29c905");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "6cdbfa3b-6575-4af6-ae7c-87a8007f1e03");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a33db965-3c7a-430c-831b-864038522af1", "AQAAAAEAACcQAAAAEIl/WpyaNT1dXPDcFPbn0FXNAZKV0S2Z9NxEAKqclqRy+z32ft+1lchvjNkoqCCCcg==", "128651aa-0795-4a05-a6b3-21f32ea81d31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e23349e3-2c7a-4a04-aaf4-9da667a8dcda", "AQAAAAEAACcQAAAAEBXYWtO/XoDCQFSZduOrTxrMykhw/VESH0aaxBXS9aiElbuwmvxbWpOmacWAW8QkZA==", "08c87ad9-d75f-405e-88d8-0d7183fad800" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b6c26b8-3b2e-4008-ae49-f8ceffea599e", "AQAAAAEAACcQAAAAEBPpoaEgalQr5Wa6JBGTPQSHinHmgPhptvhAs3toymflmA7kUjre+xHdws6HmVfPQA==", "c15338fe-5cae-47e4-91ff-e225bc4c19ca" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 11, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 26, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 3, 15, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedOn",
                value: new DateTime(2024, 2, 11, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedOn",
                value: new DateTime(2023, 9, 11, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedOn",
                value: new DateTime(2024, 4, 11, 10, 13, 10, 768, DateTimeKind.Local).AddTicks(1213));
        }
    }
}
