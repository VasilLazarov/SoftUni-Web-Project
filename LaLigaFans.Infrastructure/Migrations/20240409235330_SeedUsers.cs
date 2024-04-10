using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18c72cdd-60c4-4a26-b931-d183cb23e593", "2ab92897-64a5-455a-966f-2cb2939939d6", "Administrator", "ADMINISTRATOR" },
                    { "91accf42-f5d3-47ee-8300-4671d5b47e46", "2712769e-c688-4632-96d6-140028c765d9", "Publisher", "PUBLISHER" },
                    { "f9725b78-b6af-40c1-90d4-f77de178c1fd", "e442f585-cd4e-428b-8b06-510065d0a0e0", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "176d92cc-bdaf-4569-94b8-fa377f980d89", 0, "39487426-97fb-4a00-85ba-9d41e205c8d7", "publisher@gmail.com", false, "Publisher", "Ivanov", false, null, "PUBLISHER@GMAIL.COM", "PUBLISHER@GMAIL.COM", "AQAAAAEAACcQAAAAEOFW1tWWTP0DpoSdEePbbp47W9P8BTcyHTTRSA43xFRySgaf5HhGnlfEICbScXQFyg==", null, false, "fef8d58f-dc46-46e6-8d3d-4c15faf03664", false, "publisher@gmail.com" },
                    { "1dcd54f5-dc66-4540-8cf9-d44658029bfd", 0, "e24278b8-88a4-4603-8c24-701350e88ff9", "admin@gmail.com", false, "Admin", "Adminov", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEAUc7WUMlaLO3GLZRZELUBDvMLiA73DmaQjeMBuQGWCgcMITnS85eHXQNZDa4/IPtw==", null, false, "2f303c6b-3fe7-451d-bf3b-79ba955d37bf", false, "admin@gmail.com" },
                    { "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6", 0, "4ba84077-d27d-47ea-a498-c31ad441354b", "user1@gmail.com", false, "User", "Userov", false, null, "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAEAACcQAAAAEP/pE817jdSmjUGZCO1uIpIPmlvvmAGqvfqjRiQGVWpblnhY4z5W1Bsu0k32uIO4Tw==", null, false, "c59fecc5-d6cb-4adb-b49f-322c10500577", false, "user1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Admin Adminov", "1dcd54f5-dc66-4540-8cf9-d44658029bfd" },
                    { 2, "user:fullname", "Publisher Ivanov", "176d92cc-bdaf-4569-94b8-fa377f980d89" },
                    { 3, "user:fullname", "User Userov", "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "91accf42-f5d3-47ee-8300-4671d5b47e46", "176d92cc-bdaf-4569-94b8-fa377f980d89" },
                    { "18c72cdd-60c4-4a26-b931-d183cb23e593", "1dcd54f5-dc66-4540-8cf9-d44658029bfd" },
                    { "f9725b78-b6af-40c1-90d4-f77de178c1fd", "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "91accf42-f5d3-47ee-8300-4671d5b47e46", "176d92cc-bdaf-4569-94b8-fa377f980d89" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18c72cdd-60c4-4a26-b931-d183cb23e593", "1dcd54f5-dc66-4540-8cf9-d44658029bfd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9725b78-b6af-40c1-90d4-f77de178c1fd", "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6");
        }
    }
}
