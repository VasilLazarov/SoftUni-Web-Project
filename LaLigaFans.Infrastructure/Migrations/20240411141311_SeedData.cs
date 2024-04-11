using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[,]
                {
                    { 1, "1dcd54f5-dc66-4540-8cf9-d44658029bfd" },
                    { 2, "176d92cc-bdaf-4569-94b8-fa377f980d89" },
                    { 3, "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "T-Shirt" },
                    { 2, "Scarf" },
                    { 3, "Ball" },
                    { 4, "Cup" },
                    { 5, "Bag" },
                    { 6, "Keychain" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachName", "FoundedYear", "Information", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Xavi Hernandez", 1899, "Barcelona football club is one of the top teams in the Spanish football league. It was founded on November 29, 1899. The team's stadium is called \"Camp Nou\" and has a capacity of 105 thousand seats. The Barcelona team has won the Champions League five times, the FIFA Club World Cup three times, the Spanish Championship twenty-seven times, the Copa del Rey thirty-one times, the Spanish Super Cup fourteen times and many more.", "BarcelonaLogo.png", "Barcelona" },
                    { 2, "Carlo Ancelotti", 1902, "Real Madrid football club is one of the top teams in the Spanish football league. It was founded on March 6, 1902. The team's stadium is called \"Santiago Bernabeu\" and has a capacity of 83 thousand seats. The Real Madrid team has won the Champions League eight times, the FIFA Club World Cup eight times, the Spanish Championship thirty-five times, the Copa del Rey twenty times, the Spanish Super Cup thirteen times and many more.", "RealMadridLogo.png", "Real Madrid" },
                    { 3, "Diego Simeone", 1903, "Atletico Madrid football club is one of the top teams in the Spanish football league. It was founded on April 26, 1903. The team's stadium is called \"Metropolitano\" and has a capacity of 70 thousand seats. The Atlético Madrid team has won three times the Europa League, eleven times the Spanish Championship, ten times the Copa del Rey, two times the Spanish Super Cup and others.", "AtleticoMadridLogo.png", "Atletico Madrid" },
                    { 4, "Ruben Baraja", 1919, "Valencia football club is one of the teams in the Spanish football league. It was founded on March 18, 1919. The team's stadium is called \"Camp de Mestalla\" and has a capacity of 50 thousand seats. The Valencia team has won the Spanish Championship six times, the Copa del Rey eight times, the Spanish Super Cup once and others.", "ValenciaLogo.png", "Valencia" },
                    { 5, "Quiwue Sanchez", 1890, "Sevilla football club is one of the teams in the Spanish football league. It was founded on January 25, 1890. The team's stadium is called \"Ramon Sanchez Pizjuan\" and has a capacity of 43 thousand seats. The Sevilla team has won the Europa League five times, the Spanish Championship once, the Copa del Rey five times, the Spanish Super Cup once and others.", "SevillaLogo.png", "Sevilla" },
                    { 6, "Michel Sanchez", 1930, "Girona football club is one of the teams in the Spanish football league. It was founded on July 23, 1930. The team's stadium is called \"Municipal de Montilivi\" and has a capacity of 15 thousand seats. The team of Girona has won the second Spanish Championship once, the third Spanish Championship five times, the Super Cup of Catalonia once and others.", "GironaLogo.png", "Girona" },
                    { 7, "Luis Garcia", 1921, "Alaves football club is one of the teams in the Spanish football league. It was founded on January 23, 1921. The team's stadium is called \"Mendizorroza\" and has a capacity of 20 thousand seats. The Alaves team has won the second Spanish championship four times, the third Spanish championship twice, the Copa del Rey once and others.", "AlavesLogo.png", "Alaves" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "DisLikes", "ImageURL", "Likes", "OwnerId", "PublishedOn", "TeamId", "Title" },
                values: new object[,]
                {
                    { 1, "The Barcelona team won 3:2 away from Paris Saint-Germain in the first 1/4-final match of the Champions League.\r\nRafinha gave the Catalans the lead in the 37th minute, but early in the second half PSG made a quick turnaround through Ousmane Dembele in the 48th minute and Vitinha in the 51st minute. After that, however, the Catalans took the initiative again and in the 62nd minute the tie was restored with Rafinha's second goal. In the end, the final result was shaped by Andreas Christensen's goal in the 77th minute, which brought victory to Barca.\r\nThe second match between the two teams will be on April 16th in Spain, where we can expect another very interesting match.", 0, "BarcaNews1.png", 0, "176d92cc-bdaf-4569-94b8-fa377f980d89", new DateTime(2024, 4, 11, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1202), 1, "Barcelona crushed PSG and took the lead ahead of the second leg" },
                    { 2, "The Barcelona team could not beat the Athletic Bilbao team and the match ended 0:0, with which the Catalans lost 2 more points in the standings and are now 8 points away from the first in the standings.\r\nThere are only 5 rounds left in the championship and Barcelona's chances of catching up to first place are already minimal.\r\nFor the Catalans, it remains to fight for a trophy in the Champions League, where they will face a quarter-final match against a team from Paris Saint-Germain, and for the Copa del Rey in Spain, where they will play against a Sevilla team in the semi-finals.", 0, "BarcaNews2.png", 0, "176d92cc-bdaf-4569-94b8-fa377f980d89", new DateTime(2023, 12, 26, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1206), 1, "Barcelona with new lost points in La Liga" },
                    { 3, "Real Madrid and Manchester City had a very spectacular and interesting match in their first leg of the quarter-finals of the Champions League, which ended in a 3-3 draw.\r\nAt the very beginning of the match, Manchester City took the lead with a goal by Bernardo Silva in the 2nd minute, but then Real Madrid scored two goals, the first of which was an own goal by Ruben Diaz in the 12th minute, and the second goal was by Rodrigo Goes in the 14th minute. However, City then turned the score around again with goals from Phil Foden in the 66th minute and Josko Guardiol in the 71st minute. And finally Federico Valverde scored for Real and that's how the final score was 3:3.\r\nThe second match between the two teams will be on April 17.", 0, "RealNews1.png", 0, "176d92cc-bdaf-4569-94b8-fa377f980d89", new DateTime(2024, 3, 15, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1208), 2, "Real Madrid and Manchester City could not beat each other" },
                    { 4, "The Real Madrid team convincingly defeated the Osasuna team with 4:0 and now leads the La Liga standings ahead of the second by 8 points.\r\nOnly 4 rounds remain until the end of the championship and Real are already very close to the title this season.\r\nIn addition to La Liga, Real also have matches in the quarter-finals of the Champions League against the Manchester City team, as well as the semi-final of the King's Cup in Spain against the Valencia team.\r\nIf Real manage to win all three they will complete a treble this season, which they haven't done in a long time.", 0, "RealNews2.png", 0, "176d92cc-bdaf-4569-94b8-fa377f980d89", new DateTime(2024, 2, 11, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1209), 2, "Real Madrid with another victory in La Liga" },
                    { 5, "The Atletico Madrid team managed to beat Borussia Dortmund in a very close match in the first round of the quarter-finals of the Champions League.\r\nAtlético took the lead early in the match with a goal from Rodrigo De Paul in the 4th minute, then they made it 2-0 with a goal from Samuel Lino in the 32nd minute. Finally, Dortmund pulled one back with a goal from Sebastien Alle in the 81st minute and the match ended 2:1 for the Atlético team.\r\nThe second match between the two teams will be on April 16th, and we expect a very even game from both teams again.", 0, "AtleticoNews.png", 0, "176d92cc-bdaf-4569-94b8-fa377f980d89", new DateTime(2023, 9, 11, 17, 13, 10, 768, DateTimeKind.Local).AddTicks(1211), 3, "Atletico Madrid with a tough win against Borussia Dortmund" },
                    { 6, "The Sevilla team achieved a hard-fought victory in La Liga against the Getafe team, but with this victory, the Sevilla team managed to move away from the relegation group that they were very close to before this match.\r\nThe only goal in the match was scored by Sergio Ramost, with which the Sevilla team won with a score of 0:1.\r\nUntil the end of the championship, the Sevilla team has 6 more games left in which they must manage to win points to stay above the relegation group.\r\nSevilla's next game is against Las Palmas on April 14th.", 0, "SevillaNews.png", 0, "176d92cc-bdaf-4569-94b8-fa377f980d89", new DateTime(2024, 4, 11, 10, 13, 10, 768, DateTimeKind.Local).AddTicks(1213), 5, "Sevilla with a difficult but important victory" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "PlayerImageUrl", "TeamId" },
                values: new object[,]
                {
                    { 1, 31, "Marc-Andre", "ter Stegen", "TerStegen.png", 1 },
                    { 2, 26, "Frenkie", "de Jong", "Frenki.png", 1 },
                    { 3, 29, "Joao", "Cancelo", "Cancelo.png", 1 },
                    { 4, 35, "Robert", "Lewandowski", "Lewandowski.png", 1 },
                    { 5, 24, "Joao", "Felix", "Felix.png", 1 },
                    { 6, 31, "Thibaut", "Courtois", "Courtois.png", 2 },
                    { 7, 32, "Lucas", "Vazquez", "Vazquez.png", 2 },
                    { 8, 32, "Dani", "Carvajal", "Carvajal.png", 2 },
                    { 9, 23, "Vinicius", "Junior", "ViniJR.png", 2 },
                    { 10, 31, "Jan", "Oblak", "Oblak.png", 3 },
                    { 11, 35, "Axel", "Witsel", "Witsel.png", 3 },
                    { 12, 28, "Jose", "Gaya", "Gaya.png", 4 },
                    { 13, 32, "Nemanja", "Gudelj", "Gudelj.png", 5 },
                    { 14, 23, "Eric", "Garcia", "Garcia.png", 6 },
                    { 15, 26, "Ander", "Guevara", "Guevara.png", 7 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DisLikes", "ImageURL", "Likes", "Name", "Price", "TeamId", "UnitsAvailable" },
                values: new object[,]
                {
                    { 1, 1, "Original Barcelona t-shirt made of 100% breathable fabric.", 0, "BarcaTShirt.png", 0, "Barcelona T-Shirt", 34.99m, 1, 10 },
                    { 2, 2, "Original Barcelona scarf made of cotton and synthetic fabric.", 0, "BarcaScarf.png", 0, "Barcelona Scarf", 22.99m, 1, 10 },
                    { 3, 3, "Original Barcelona size 5 ball made of synthetic materials.", 0, "BarcaBall.png", 0, "Barcelona Ball", 29.99m, 1, 10 },
                    { 4, 4, "Original Barcelona tea cup made of porcelain.", 0, "BarcaCup.png", 0, "Barcelona Cup", 17.99m, 1, 10 },
                    { 5, 5, "Original Barcelona bag made of synthetic waterproof material.", 0, "BarcaBag.png", 0, "Barcelona Bag", 24.99m, 1, 10 },
                    { 6, 6, "Original Barcelona keychain made of stainless steel.", 0, "BarcaKeychain.png", 0, "Barcelona Keychain", 12.99m, 1, 10 },
                    { 7, 1, "Original Real Madrid t-shirt made of 100% breathable fabric.", 0, "RealTShirt.png", 0, "Real Madrid T-Shirt", 34.99m, 2, 10 },
                    { 8, 2, "Original Real Madrid scarf made of cotton and synthetic fabric.", 0, "RealScarf.png", 0, "Real Madrid Scarf", 22.99m, 2, 10 },
                    { 9, 3, "Original Real Madrid size 5 ball made of synthetic materials.", 0, "RealBall.png", 0, "Real Madrid Ball", 29.99m, 2, 10 },
                    { 10, 4, "Original Real Madrid tea cup made of porcelain.", 0, "RealCup.png", 0, "Real Madrid Cup", 17.99m, 2, 10 },
                    { 11, 5, "Original Real Madrid bag made of synthetic waterproof material.", 0, "RealBag.png", 0, "Real Madrid Bag", 24.99m, 2, 10 },
                    { 12, 6, "Original Real Madrid keychain made of stainless steel.", 0, "RealKeychain.png", 0, "Real Madrid Keychain", 12.99m, 2, 10 },
                    { 13, 1, "Original Atletico Madrid t-shirt made of 100% breathable fabric.", 0, "AtleticoTShirt.png", 0, "Atletico Madrid T-Shirt", 30.99m, 3, 10 },
                    { 14, 2, "Original Atletico Madrid scarf made of cotton and synthetic fabric.", 0, "AtleticoScarf.png", 0, "Atletico Madrid Scarf", 19.99m, 3, 10 },
                    { 15, 3, "Original Atletico Madrid size 5 ball made of synthetic materials.", 0, "AtleticoBall.png", 0, "Atletico Ball", 25.99m, 3, 10 },
                    { 16, 4, "Original Atletico Madrid tea cup made of porcelain.", 0, "AtleticoCup.png", 0, "Atletico Madrid Cup", 14.99m, 3, 10 },
                    { 17, 5, "Original Atletico Madrid bag made of synthetic waterproof material.", 0, "AtleticoBag.png", 0, "Atletico Madrid Bag", 21.99m, 3, 10 },
                    { 18, 6, "Original Atletico Madrid keychain made of stainless steel.", 0, "AtleticoKeychain.png", 0, "Atletico Madrid Keychain", 10.99m, 3, 10 },
                    { 19, 1, "Original Valencia t-shirt made of 100% breathable fabric.", 0, "ValenciaTShirt.png", 0, "Valencia T-Shirt", 24.99m, 4, 10 },
                    { 20, 2, "Original Valencia scarf made of cotton and synthetic fabric.", 0, "ValenciaScarf.png", 0, "Valencia Scarf", 16.99m, 4, 10 },
                    { 21, 1, "Original Sevilla t-shirt made of 100% breathable fabric.", 0, "SevillaTShirt.png", 0, "Sevilla T-Shirt", 22.49m, 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DisLikes", "ImageURL", "Likes", "Name", "Price", "TeamId", "UnitsAvailable" },
                values: new object[] { 22, 3, "Original Sevilla size 5 ball made of synthetic materials.", 0, "SevillaBall.png", 0, "Sevilla Ball", 20.99m, 5, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DisLikes", "ImageURL", "Likes", "Name", "Price", "TeamId", "UnitsAvailable" },
                values: new object[] { 23, 1, "Original Girona t-shirt made of 100% breathable fabric.", 0, "GironaTShirt.png", 0, "Girona T-Shirt", 19.99m, 6, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DisLikes", "ImageURL", "Likes", "Name", "Price", "TeamId", "UnitsAvailable" },
                values: new object[] { 24, 1, "Original Alaves t-shirt made of 100% breathable fabric.", 0, "AlavesTShirt.png", 0, "Alaves T-Shirt", 19.99m, 7, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c72cdd-60c4-4a26-b931-d183cb23e593",
                column: "ConcurrencyStamp",
                value: "2ab92897-64a5-455a-966f-2cb2939939d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91accf42-f5d3-47ee-8300-4671d5b47e46",
                column: "ConcurrencyStamp",
                value: "2712769e-c688-4632-96d6-140028c765d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                column: "ConcurrencyStamp",
                value: "e442f585-cd4e-428b-8b06-510065d0a0e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176d92cc-bdaf-4569-94b8-fa377f980d89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39487426-97fb-4a00-85ba-9d41e205c8d7", "AQAAAAEAACcQAAAAEOFW1tWWTP0DpoSdEePbbp47W9P8BTcyHTTRSA43xFRySgaf5HhGnlfEICbScXQFyg==", "fef8d58f-dc46-46e6-8d3d-4c15faf03664" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e24278b8-88a4-4603-8c24-701350e88ff9", "AQAAAAEAACcQAAAAEAUc7WUMlaLO3GLZRZELUBDvMLiA73DmaQjeMBuQGWCgcMITnS85eHXQNZDa4/IPtw==", "2f303c6b-3fe7-451d-bf3b-79ba955d37bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ba84077-d27d-47ea-a498-c31ad441354b", "AQAAAAEAACcQAAAAEP/pE817jdSmjUGZCO1uIpIPmlvvmAGqvfqjRiQGVWpblnhY4z5W1Bsu0k32uIO4Tw==", "c59fecc5-d6cb-4adb-b49f-322c10500577" });
        }
    }
}
