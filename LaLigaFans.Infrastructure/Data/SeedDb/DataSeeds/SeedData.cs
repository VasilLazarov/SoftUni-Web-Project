using LaLigaFans.Infrastructure.Data.Models;

namespace LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds
{
    internal class SeedData
    {
        public Cart AdminCart { get; set; } = null!;

        public Cart PublisherCart { get; set; } = null!;
        
        public Cart UserCart { get; set; } = null!;


        public Team Barcelona { get; set; } = null!;
        
        public Team RealMadrid { get; set; } = null!;

        public Team AtleticoMadrid { get; set; } = null!;

        public Team Valencia { get; set; } = null!;

        public Team Sevilla { get; set; } = null!;

        public Team Girona { get; set; } = null!;

        public Team Alaves { get; set; } = null!;


        public Player BarcaPlayer1 { get; set; } = null!;

        public Player BarcaPlayer2 { get; set; } = null!;

        public Player BarcaPlayer3 { get; set; } = null!;

        public Player BarcaPlayer4 { get; set; } = null!;

        public Player BarcaPlayer5 { get; set; } = null!;

        public Player RealPlayer1 { get; set; } = null!;

        public Player RealPlayer2 { get; set; } = null!;

        public Player RealPlayer3 { get; set; } = null!;

        public Player RealPlayer4 { get; set; } = null!;

        public Player AtleticoPlayer1 { get; set; } = null!;

        public Player AtleticoPlayer2 { get; set; } = null!;

        public Player ValenciaPlayer { get; set; } = null!;

        public Player SevillaPlayer { get; set; } = null!;

        public Player GironaPlayer { get; set; } = null!;

        public Player AlavesPlayer { get; set; } = null!;


        public News News1 { get; set; } = null!;

        public News News2 { get; set; } = null!;

        public News News3 { get; set; } = null!;

        public News News4 { get; set; } = null!;

        public News News5 { get; set; } = null!;

        public News News6 { get; set; } = null!;


        public Category TShirt { get; set; } = null!;

        public Category Scarf { get; set; } = null!;

        public Category Ball { get; set; } = null!;

        public Category Cup { get; set; } = null!;

        public Category Bag { get; set; } = null!;

        public Category Keychain { get; set; } = null!;


        public Product BarcaTShirt { get; set; } = null!;

        public Product BarcaScarf { get; set; } = null!;

        public Product BarcaBall { get; set; } = null!;

        public Product BarcaCup { get; set; } = null!;

        public Product BarcaBag { get; set; } = null!;

        public Product BarcaKeychain { get; set; } = null!;

        public Product RealTShirt { get; set; } = null!;

        public Product RealScarf { get; set; } = null!;

        public Product RealBall { get; set; } = null!;

        public Product RealCup { get; set; } = null!;

        public Product RealBag { get; set; } = null!;

        public Product RealKeychain { get; set; } = null!;

        public Product AtleticoTShirt { get; set; } = null!;

        public Product AtleticoScarf { get; set; } = null!;

        public Product AtleticoBall { get; set; } = null!;

        public Product AtleticoCup { get; set; } = null!;

        public Product AtleticoBag { get; set; } = null!;

        public Product AtleticoKeychain { get; set; } = null!;

        public Product ValenciaTShirt { get; set; } = null!;

        public Product ValenciaScarf { get; set; } = null!;

        public Product SevillaTShirt { get; set; } = null!;

        public Product SevillaBall { get; set; } = null!;

        public Product GironaTShirt { get; set; } = null!;

        public Product AlavesTShirt { get; set; } = null!;




        public SeedData()
        {
            SeedCarts();
            SeedTeams();
            SeedPlayers();
            SeedNews();
            SeedCategories();
            SeedProducts();
        }


        private void SeedCarts()
        {
            AdminCart = new Cart()
            {
                Id = 1,
                ApplicationUserId = "1dcd54f5-dc66-4540-8cf9-d44658029bfd"
            };

            PublisherCart = new Cart()
            {
                Id = 2,
                ApplicationUserId = "176d92cc-bdaf-4569-94b8-fa377f980d89"
            };

            UserCart = new Cart()
            {
                Id = 3,
                ApplicationUserId = "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6"
            };
        }

        private void SeedTeams()
        {
            Barcelona = new Team()
            {
                Id = 1,
                Name = "Barcelona",
                LogoUrl = "BarcelonaLogo.png",
                FoundedYear = 1899,
                CoachName = "Xavi Hernandez",
                Information = "Barcelona football club is one of the top teams in the Spanish football league. It was founded on November 29, 1899. The team's stadium is called \"Camp Nou\" and has a capacity of 105 thousand seats. The Barcelona team has won the Champions League five times, the FIFA Club World Cup three times, the Spanish Championship twenty-seven times, the Copa del Rey thirty-one times, the Spanish Super Cup fourteen times and many more."
            };

            RealMadrid = new Team()
            {
                Id= 2,
                Name = "Real Madrid",
                LogoUrl = "RealMadridLogo.png",
                FoundedYear = 1902,
                CoachName = "Carlo Ancelotti",
                Information = "Real Madrid football club is one of the top teams in the Spanish football league. It was founded on March 6, 1902. The team's stadium is called \"Santiago Bernabeu\" and has a capacity of 83 thousand seats. The Real Madrid team has won the Champions League eight times, the FIFA Club World Cup eight times, the Spanish Championship thirty-five times, the Copa del Rey twenty times, the Spanish Super Cup thirteen times and many more."
            };

            AtleticoMadrid = new Team()
            {
                Id = 3,
                Name = "Atletico Madrid",
                LogoUrl = "AtleticoMadridLogo.png",
                FoundedYear = 1903,
                CoachName = "Diego Simeone",
                Information = "Atletico Madrid football club is one of the top teams in the Spanish football league. It was founded on April 26, 1903. The team's stadium is called \"Metropolitano\" and has a capacity of 70 thousand seats. The Atlético Madrid team has won three times the Europa League, eleven times the Spanish Championship, ten times the Copa del Rey, two times the Spanish Super Cup and others."
            };

            Valencia = new Team()
            {
                Id = 4,
                Name = "Valencia",
                LogoUrl = "ValenciaLogo.png",
                FoundedYear = 1919,
                CoachName = "Ruben Baraja",
                Information = "Valencia football club is one of the teams in the Spanish football league. It was founded on March 18, 1919. The team's stadium is called \"Camp de Mestalla\" and has a capacity of 50 thousand seats. The Valencia team has won the Spanish Championship six times, the Copa del Rey eight times, the Spanish Super Cup once and others."
            };

            Sevilla = new Team()
            {
                Id = 5,
                Name = "Sevilla",
                LogoUrl = "SevillaLogo.png",
                FoundedYear = 1890,
                CoachName = "Quiwue Sanchez",
                Information = "Sevilla football club is one of the teams in the Spanish football league. It was founded on January 25, 1890. The team's stadium is called \"Ramon Sanchez Pizjuan\" and has a capacity of 43 thousand seats. The Sevilla team has won the Europa League five times, the Spanish Championship once, the Copa del Rey five times, the Spanish Super Cup once and others."
            };

            Girona = new Team()
            {
                Id = 6,
                Name = "Girona",
                LogoUrl = "GironaLogo.png",
                FoundedYear = 1930,
                CoachName = "Michel Sanchez",
                Information = "Girona football club is one of the teams in the Spanish football league. It was founded on July 23, 1930. The team's stadium is called \"Municipal de Montilivi\" and has a capacity of 15 thousand seats. The team of Girona has won the second Spanish Championship once, the third Spanish Championship five times, the Super Cup of Catalonia once and others."
            };

            Alaves = new Team()
            {
                Id = 7,
                Name = "Alaves",
                LogoUrl = "AlavesLogo.png",
                FoundedYear = 1921,
                CoachName = "Luis Garcia",
                Information = "Alaves football club is one of the teams in the Spanish football league. It was founded on January 23, 1921. The team's stadium is called \"Mendizorroza\" and has a capacity of 20 thousand seats. The Alaves team has won the second Spanish championship four times, the third Spanish championship twice, the Copa del Rey once and others."
            };
        }

        private void SeedPlayers()
        {
            BarcaPlayer1 = new Player()
            {
                Id = 1,
                FirstName = "Marc-Andre",
                LastName = "ter Stegen",
                Age = 31,
                PlayerImageUrl = "TerStegen.png",
                TeamId = Barcelona.Id
            };

            BarcaPlayer2 = new Player()
            {
                Id = 2,
                FirstName = "Frenkie",
                LastName = "de Jong",
                Age = 26,
                PlayerImageUrl = "Frenki.png",
                TeamId = Barcelona.Id
            };

            BarcaPlayer3 = new Player()
            {
                Id = 3,
                FirstName = "Joao",
                LastName = "Cancelo",
                Age = 29,
                PlayerImageUrl = "Cancelo.png",
                TeamId = Barcelona.Id
            };

            BarcaPlayer4 = new Player()
            {
                Id = 4,
                FirstName = "Robert",
                LastName = "Lewandowski",
                Age = 35,
                PlayerImageUrl = "Lewandowski.png",
                TeamId = Barcelona.Id
            };

            BarcaPlayer5 = new Player()
            {
                Id = 5,
                FirstName = "Joao",
                LastName = "Felix",
                Age = 24,
                PlayerImageUrl = "Felix.png",
                TeamId = Barcelona.Id
            };

            RealPlayer1 = new Player()
            {
                Id = 6,
                FirstName = "Thibaut",
                LastName = "Courtois",
                Age = 31,
                PlayerImageUrl = "Courtois.png",
                TeamId = RealMadrid.Id
            };

            RealPlayer2 = new Player()
            {
                Id = 7,
                FirstName = "Lucas",
                LastName = "Vazquez",
                Age = 32,
                PlayerImageUrl = "Vazquez.png",
                TeamId = RealMadrid.Id
            };

            RealPlayer3 = new Player()
            {
                Id = 8,
                FirstName = "Dani",
                LastName = "Carvajal",
                Age = 32,
                PlayerImageUrl = "Carvajal.png",
                TeamId = RealMadrid.Id
            };

            RealPlayer4 = new Player()
            {
                Id = 9,
                FirstName = "Vinicius",
                LastName = "Junior",
                Age = 23,
                PlayerImageUrl = "ViniJR.png",
                TeamId = RealMadrid.Id
            };

            AtleticoPlayer1 = new Player()
            {
                Id = 10,
                FirstName = "Jan",
                LastName = "Oblak",
                Age = 31,
                PlayerImageUrl = "Oblak.png",
                TeamId = AtleticoMadrid.Id
            };

            AtleticoPlayer2 = new Player()
            {
                Id = 11,
                FirstName = "Axel",
                LastName = "Witsel",
                Age = 35,
                PlayerImageUrl = "Witsel.png",
                TeamId = AtleticoMadrid.Id
            };

            ValenciaPlayer = new Player()
            {
                Id = 12,
                FirstName = "Jose",
                LastName = "Gaya",
                Age = 28,
                PlayerImageUrl = "Gaya.png",
                TeamId = Valencia.Id
            };

            SevillaPlayer = new Player()
            {
                Id = 13,
                FirstName = "Nemanja",
                LastName = "Gudelj",
                Age = 32,
                PlayerImageUrl = "Gudelj.png",
                TeamId = Sevilla.Id
            };

            GironaPlayer = new Player()
            {
                Id = 14,
                FirstName = "Eric",
                LastName = "Garcia",
                Age = 23,
                PlayerImageUrl = "Garcia.png",
                TeamId = Girona.Id
            };

            AlavesPlayer = new Player()
            {
                Id = 15,
                FirstName = "Ander",
                LastName = "Guevara",
                Age = 26,
                PlayerImageUrl = "Guevara.png",
                TeamId = Alaves.Id
            };
        }

        private void SeedNews()
        {
            News1 = new News()
            {
                Id = 1,
                Title = "Barcelona crushed PSG and took the lead ahead of the second leg",
                ImageURL = "BarcaNews1.png",
                Content = "The Barcelona team won 3:2 away from Paris Saint-Germain in the first 1/4-final match of the Champions League.\r\nRafinha gave the Catalans the lead in the 37th minute, but early in the second half PSG made a quick turnaround through Ousmane Dembele in the 48th minute and Vitinha in the 51st minute. After that, however, the Catalans took the initiative again and in the 62nd minute the tie was restored with Rafinha's second goal. In the end, the final result was shaped by Andreas Christensen's goal in the 77th minute, which brought victory to Barca.\r\nThe second match between the two teams will be on April 16th in Spain, where we can expect another very interesting match.",
                PublishedOn = DateTime.Now,
                TeamId = Barcelona.Id,
                OwnerId = "176d92cc-bdaf-4569-94b8-fa377f980d89"
            };

            News2 = new News()
            {
                Id = 2,
                Title = "Barcelona with new lost points in La Liga",
                ImageURL = "BarcaNews2.png",
                Content = "The Barcelona team could not beat the Athletic Bilbao team and the match ended 0:0, with which the Catalans lost 2 more points in the standings and are now 8 points away from the first in the standings.\r\nThere are only 5 rounds left in the championship and Barcelona's chances of catching up to first place are already minimal.\r\nFor the Catalans, it remains to fight for a trophy in the Champions League, where they will face a quarter-final match against a team from Paris Saint-Germain, and for the Copa del Rey in Spain, where they will play against a Sevilla team in the semi-finals.",
                PublishedOn = DateTime.Now.AddDays(-107),
                TeamId = Barcelona.Id,
                OwnerId = "176d92cc-bdaf-4569-94b8-fa377f980d89"
            };

            News3 = new News()
            {
                Id = 3,
                Title = "Real Madrid and Manchester City could not beat each other",
                ImageURL = "RealNews1.png",
                Content = "Real Madrid and Manchester City had a very spectacular and interesting match in their first leg of the quarter-finals of the Champions League, which ended in a 3-3 draw.\r\nAt the very beginning of the match, Manchester City took the lead with a goal by Bernardo Silva in the 2nd minute, but then Real Madrid scored two goals, the first of which was an own goal by Ruben Diaz in the 12th minute, and the second goal was by Rodrigo Goes in the 14th minute. However, City then turned the score around again with goals from Phil Foden in the 66th minute and Josko Guardiol in the 71st minute. And finally Federico Valverde scored for Real and that's how the final score was 3:3.\r\nThe second match between the two teams will be on April 17.",
                PublishedOn = DateTime.Now.AddDays(-27),
                TeamId = RealMadrid.Id,
                OwnerId = "176d92cc-bdaf-4569-94b8-fa377f980d89"
            };

            News4 = new News()
            {
                Id = 4,
                Title = "Real Madrid with another victory in La Liga",
                ImageURL = "RealNews2.png",
                Content = "The Real Madrid team convincingly defeated the Osasuna team with 4:0 and now leads the La Liga standings ahead of the second by 8 points.\r\nOnly 4 rounds remain until the end of the championship and Real are already very close to the title this season.\r\nIn addition to La Liga, Real also have matches in the quarter-finals of the Champions League against the Manchester City team, as well as the semi-final of the King's Cup in Spain against the Valencia team.\r\nIf Real manage to win all three they will complete a treble this season, which they haven't done in a long time.",
                PublishedOn = DateTime.Now.AddMonths(-2),
                TeamId = RealMadrid.Id,
                OwnerId = "176d92cc-bdaf-4569-94b8-fa377f980d89"
            };

            News5 = new News()
            {
                Id = 5,
                Title = "Atletico Madrid with a tough win against Borussia Dortmund",
                ImageURL = "AtleticoNews.png",
                Content = "The Atletico Madrid team managed to beat Borussia Dortmund in a very close match in the first round of the quarter-finals of the Champions League.\r\nAtlético took the lead early in the match with a goal from Rodrigo De Paul in the 4th minute, then they made it 2-0 with a goal from Samuel Lino in the 32nd minute. Finally, Dortmund pulled one back with a goal from Sebastien Alle in the 81st minute and the match ended 2:1 for the Atlético team.\r\nThe second match between the two teams will be on April 16th, and we expect a very even game from both teams again.",
                PublishedOn = DateTime.Now.AddMonths(-7),
                TeamId = AtleticoMadrid.Id,
                OwnerId = "176d92cc-bdaf-4569-94b8-fa377f980d89"
            };

            News6 = new News()
            {
                Id = 6,
                Title = "Sevilla with a difficult but important victory",
                ImageURL = "SevillaNews.png",
                Content = "The Sevilla team achieved a hard-fought victory in La Liga against the Getafe team, but with this victory, the Sevilla team managed to move away from the relegation group that they were very close to before this match.\r\nThe only goal in the match was scored by Sergio Ramost, with which the Sevilla team won with a score of 0:1.\r\nUntil the end of the championship, the Sevilla team has 6 more games left in which they must manage to win points to stay above the relegation group.\r\nSevilla's next game is against Las Palmas on April 14th.",
                PublishedOn = DateTime.Now.AddHours(-7),
                TeamId = Sevilla.Id,
                OwnerId = "176d92cc-bdaf-4569-94b8-fa377f980d89"
            };
        }

        private void SeedCategories()
        {
            TShirt = new Category()
            {
                Id = 1,
                Name = "T-Shirt"
            };

            Scarf = new Category()
            {
                Id = 2,
                Name = "Scarf"
            };

            Ball = new Category()
            {
                Id = 3,
                Name = "Ball"
            };

            Cup = new Category()
            {
                Id = 4,
                Name = "Cup"
            };

            Bag = new Category()
            {
                Id = 5,
                Name = "Bag"
            };

            Keychain = new Category()
            {
                Id = 6,
                Name = "Keychain"
            };
        }

        private void SeedProducts()
        {
            BarcaTShirt = new Product()
            {
                Id = 1,
                Name = "Barcelona T-Shirt",
                Description = "Original Barcelona t-shirt made of 100% breathable fabric.",
                ImageURL = "BarcaTShirt.png",
                Price = 34.99M,
                UnitsAvailable = 10,
                CategoryId = TShirt.Id,
                TeamId = Barcelona.Id
            };

            BarcaScarf = new Product()
            {
                Id = 2,
                Name = "Barcelona Scarf",
                Description = "Original Barcelona scarf made of cotton and synthetic fabric.",
                ImageURL = "BarcaScarf.png",
                Price = 22.99M,
                UnitsAvailable = 10,
                CategoryId = Scarf.Id,
                TeamId = Barcelona.Id
            };

            BarcaBall = new Product()
            {
                Id = 3,
                Name = "Barcelona Ball",
                Description = "Original Barcelona size 5 ball made of synthetic materials.",
                ImageURL = "BarcaBall.png",
                Price = 29.99M,
                UnitsAvailable = 10,
                CategoryId = Ball.Id,
                TeamId = Barcelona.Id
            };

            BarcaCup = new Product()
            {
                Id = 4,
                Name = "Barcelona Cup",
                Description = "Original Barcelona tea cup made of porcelain.",
                ImageURL = "BarcaCup.png",
                Price = 17.99M,
                UnitsAvailable = 10,
                CategoryId = Cup.Id,
                TeamId = Barcelona.Id
            };

            BarcaBag = new Product()
            {
                Id = 5,
                Name = "Barcelona Bag",
                Description = "Original Barcelona bag made of synthetic waterproof material.",
                ImageURL = "BarcaBag.png",
                Price = 24.99M,
                UnitsAvailable = 10,
                CategoryId = Bag.Id,
                TeamId = Barcelona.Id
            };

            BarcaKeychain = new Product()
            {
                Id = 6,
                Name = "Barcelona Keychain",
                Description = "Original Barcelona keychain made of stainless steel.",
                ImageURL = "BarcaKeychain.png",
                Price = 12.99M,
                UnitsAvailable = 10,
                CategoryId = Keychain.Id,
                TeamId = Barcelona.Id
            };


            RealTShirt = new Product()
            {
                Id = 7,
                Name = "Real Madrid T-Shirt",
                Description = "Original Real Madrid t-shirt made of 100% breathable fabric.",
                ImageURL = "RealTShirt.png",
                Price = 34.99M,
                UnitsAvailable = 10,
                CategoryId = TShirt.Id,
                TeamId = RealMadrid.Id
            };

            RealScarf = new Product()
            {
                Id = 8,
                Name = "Real Madrid Scarf",
                Description = "Original Real Madrid scarf made of cotton and synthetic fabric.",
                ImageURL = "RealScarf.png",
                Price = 22.99M,
                UnitsAvailable = 10,
                CategoryId = Scarf.Id,
                TeamId = RealMadrid.Id
            };

            RealBall = new Product()
            {
                Id = 9,
                Name = "Real Madrid Ball",
                Description = "Original Real Madrid size 5 ball made of synthetic materials.",
                ImageURL = "RealBall.png",
                Price = 29.99M,
                UnitsAvailable = 10,
                CategoryId = Ball.Id,
                TeamId = RealMadrid.Id
            };

            RealCup = new Product()
            {
                Id = 10,
                Name = "Real Madrid Cup",
                Description = "Original Real Madrid tea cup made of porcelain.",
                ImageURL = "RealCup.png",
                Price = 17.99M,
                UnitsAvailable = 10,
                CategoryId = Cup.Id,
                TeamId = RealMadrid.Id
            };

            RealBag = new Product()
            {
                Id = 11,
                Name = "Real Madrid Bag",
                Description = "Original Real Madrid bag made of synthetic waterproof material.",
                ImageURL = "RealBag.png",
                Price = 24.99M,
                UnitsAvailable = 10,
                CategoryId = Bag.Id,
                TeamId = RealMadrid.Id
            };

            RealKeychain = new Product()
            {
                Id = 12,
                Name = "Real Madrid Keychain",
                Description = "Original Real Madrid keychain made of stainless steel.",
                ImageURL = "RealKeychain.png",
                Price = 12.99M,
                UnitsAvailable = 10,
                CategoryId = Keychain.Id,
                TeamId = RealMadrid.Id
            };


            AtleticoTShirt = new Product()
            {
                Id = 13,
                Name = "Atletico Madrid T-Shirt",
                Description = "Original Atletico Madrid t-shirt made of 100% breathable fabric.",
                ImageURL = "AtleticoTShirt.png",
                Price = 30.99M,
                UnitsAvailable = 10,
                CategoryId = TShirt.Id,
                TeamId = AtleticoMadrid.Id
            };

            AtleticoScarf = new Product()
            {
                Id = 14,
                Name = "Atletico Madrid Scarf",
                Description = "Original Atletico Madrid scarf made of cotton and synthetic fabric.",
                ImageURL = "AtleticoScarf.png",
                Price = 19.99M,
                UnitsAvailable = 10,
                CategoryId = Scarf.Id,
                TeamId = AtleticoMadrid.Id
            };

            AtleticoBall = new Product()
            {
                Id = 15,
                Name = "Atletico Ball",
                Description = "Original Atletico Madrid size 5 ball made of synthetic materials.",
                ImageURL = "AtleticoBall.png",
                Price = 25.99M,
                UnitsAvailable = 10,
                CategoryId = Ball.Id,
                TeamId = AtleticoMadrid.Id
            };

            AtleticoCup = new Product()
            {
                Id = 16,
                Name = "Atletico Madrid Cup",
                Description = "Original Atletico Madrid tea cup made of porcelain.",
                ImageURL = "AtleticoCup.png",
                Price = 14.99M,
                UnitsAvailable = 10,
                CategoryId = Cup.Id,
                TeamId = AtleticoMadrid.Id
            };

            AtleticoBag = new Product()
            {
                Id = 17,
                Name = "Atletico Madrid Bag",
                Description = "Original Atletico Madrid bag made of synthetic waterproof material.",
                ImageURL = "AtleticoBag.png",
                Price = 21.99M,
                UnitsAvailable = 10,
                CategoryId = Bag.Id,
                TeamId = AtleticoMadrid.Id
            };

            AtleticoKeychain = new Product()
            {
                Id = 18,
                Name = "Atletico Madrid Keychain",
                Description = "Original Atletico Madrid keychain made of stainless steel.",
                ImageURL = "AtleticoKeychain.png",
                Price = 10.99M,
                UnitsAvailable = 10,
                CategoryId = Keychain.Id,
                TeamId = AtleticoMadrid.Id
            };


            ValenciaTShirt = new Product()
            {
                Id = 19,
                Name = "Valencia T-Shirt",
                Description = "Original Valencia t-shirt made of 100% breathable fabric.",
                ImageURL = "ValenciaTShirt.png",
                Price = 24.99M,
                UnitsAvailable = 10,
                CategoryId = TShirt.Id,
                TeamId = Valencia.Id
            };

            ValenciaScarf = new Product()
            {
                Id = 20,
                Name = "Valencia Scarf",
                Description = "Original Valencia scarf made of cotton and synthetic fabric.",
                ImageURL = "ValenciaScarf.png",
                Price = 16.99M,
                UnitsAvailable = 10,
                CategoryId = Scarf.Id,
                TeamId = Valencia.Id
            };


            SevillaTShirt = new Product()
            {
                Id = 21,
                Name = "Sevilla T-Shirt",
                Description = "Original Sevilla t-shirt made of 100% breathable fabric.",
                ImageURL = "SevillaTShirt.png",
                Price = 22.49M,
                UnitsAvailable = 10,
                CategoryId = TShirt.Id,
                TeamId = Sevilla.Id
            };

            SevillaBall = new Product()
            {
                Id = 22,
                Name = "Sevilla Ball",
                Description = "Original Sevilla size 5 ball made of synthetic materials.",
                ImageURL = "SevillaBall.png",
                Price = 20.99M,
                UnitsAvailable = 10,
                CategoryId = Ball.Id,
                TeamId = Sevilla.Id
            };


            GironaTShirt = new Product()
            {
                Id = 23,
                Name = "Girona T-Shirt",
                Description = "Original Girona t-shirt made of 100% breathable fabric.",
                ImageURL = "GironaTShirt.png",
                Price = 19.99M,
                UnitsAvailable = 10,
                CategoryId = TShirt.Id,
                TeamId = Girona.Id
            };


            AlavesTShirt = new Product()
            {
                Id = 24,
                Name = "Alaves T-Shirt",
                Description = "Original Alaves t-shirt made of 100% breathable fabric.",
                ImageURL = "AlavesTShirt.png",
                Price = 19.99M,
                UnitsAvailable = 10,
                CategoryId = TShirt.Id,
                TeamId = Alaves.Id
            };

        }
    }
}
