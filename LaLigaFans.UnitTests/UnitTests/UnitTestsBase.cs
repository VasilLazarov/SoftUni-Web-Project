using LaLigaFans.Infrastructure.Data;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using LaLigaFans.UnitTests.Mocks;

namespace LaLigaFans.UnitTests.UnitTests
{
    public class UnitTestsBase
    {
        protected LaLigaFansDbContext context;

        protected IRepository repository;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            context = DatabaseMock.Instance;

            SeedMockedDatabase();

            repository = new Repository(context);
        }

        public ApplicationUser User1 { get; private set; }

        public ApplicationUser User2 { get; private set; }

        public ApplicationUser Publisher1 { get; private set; }

        public ApplicationUser Publisher2 { get; private set; }

        public ApplicationUser Admin { get; private set; }


        public Team Team1 { get; private set; }

        public Team Team2 { get; private set; }

        public Team Team3 { get; private set; }


        public Player Player1 { get; private set; }

        public Player Player2 { get; private set; }

        public Player Player3 { get; private set; }


        public News News1 { get; private set; }

        public News News2 { get; private set; }

        public News News3 { get; private set; }


        public Product Product1 { get; private set; }

        public Product Product2 { get; private set; }


        public Category Category1 { get; set; } = null!;

        public Category Category2 { get; set; } = null!;


        [OneTimeTearDown]
        public void TearDownBase()
            => context.Dispose();

        private void SeedMockedDatabase()
        {
            User1 = new ApplicationUser()
            {
                Id = "User1Id",
                Email = "user1@gmail.com",
                FirstName = "User1",
                LastName = "Userov1"
            };
            context.Users.Add(User1);

            User2 = new ApplicationUser()
            {
                Id = "User2Id",
                Email = "user2@gmail.com",
                FirstName = "User2",
                LastName = "Userov2"
            };
            context.Users.Add(User2);

            Publisher1 = new ApplicationUser()
            {
                Id = "Publisher1Id",
                Email = "publisher1@gmail.com",
                FirstName = "Publisher1",
                LastName = "Publisherov1"
            };
            context.Users.Add(Publisher1);

            Publisher2 = new ApplicationUser()
            {
                Id = "Publisher2Id",
                Email = "publisher2@gmail.com",
                FirstName = "Publisher2",
                LastName = "Publisherov2"
            };
            context.Users.Add(Publisher2);

            Admin = new ApplicationUser()
            {
                Id = "AdminId",
                Email = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "Adminov"
            };
            context.Users.Add(Admin);


            Team1 = new Team
            {
                Name = "Team1",
                LogoUrl = "Team1.png",
                FoundedYear = 2001,
                CoachName = "Team1Coach",
                IsActive = true,
                Information = "Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation.Team1 infrormation."
            };
            context.Teams.Add(Team1);
            User1.FollowedTeams.Add(
                new ApplicationUserTeam()
                {
                    TeamId = Team1.Id
                });

            Team2 = new Team
            {
                Name = "Team2",
                LogoUrl = "Team2.png",
                FoundedYear = 2002,
                CoachName = "Team2Coach",
                IsActive = true,
                Information = "Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information.Team2 information."
            };
            context.Teams.Add(Team2);
            User1.FollowedTeams.Add(
                new ApplicationUserTeam()
                {
                    TeamId = Team2.Id
                });

            Team3 = new Team
            {
                Name = "Team3",
                LogoUrl = "Team3.png",
                FoundedYear = 2003,
                CoachName = "Team3Coach",
                IsActive = true,
                Information = "Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information."
            };
            context.Teams.Add(Team3);


            Player1 = new Player()
            {
                FirstName = "Player1",
                LastName = "Playerov1",
                Age = 21,
                PlayerImageUrl = "Player1.png",
                Team = Team1,
                IsActive = true,
            };
            context.Players.Add(Player1);

            Player2 = new Player()
            {
                FirstName = "Player2",
                LastName = "Playerov2",
                Age = 22,
                PlayerImageUrl = "Player2.png",
                Team = Team2,
                IsActive = true,
            };
            context.Players.Add(Player2);

            Player3 = new Player()
            {
                FirstName = "Player3",
                LastName = "Playerov3",
                Age = 23,
                PlayerImageUrl = "Player3.png",
                Team = Team2,
                IsActive = true,
            };
            context.Players.Add(Player3);


            News1 = new News()
            {
                Title = "Barcelona crushed PSG and took the lead ahead of the second leg",
                ImageURL = "BarcaNews1.png",
                Content = "The Barcelona team won 3:2 away from Paris Saint-Germain in the first 1/4-final match of the Champions League.\r\nRafinha gave the Catalans the lead in the 37th minute, but early in the second half PSG made a quick turnaround through Ousmane Dembele in the 48th minute and Vitinha in the 51st minute. After that, however, the Catalans took the initiative again and in the 62nd minute the tie was restored with Rafinha's second goal. In the end, the final result was shaped by Andreas Christensen's goal in the 77th minute, which brought victory to Barca.\r\nThe second match between the two teams will be on April 16th in Spain, where we can expect another very interesting match.",
                PublishedOn = DateTime.Now,
                TeamId = Team1.Id,
                OwnerId = Publisher1.Id,
                IsActive = true,
            };
            context.News.Add(News1);

            News2 = new News()
            {
                Title = "Barcelona with new lost points in La Liga",
                ImageURL = "BarcaNews2.png",
                Content = "The Barcelona team could not beat the Athletic Bilbao team and the match ended 0:0, with which the Catalans lost 2 more points in the standings and are now 8 points away from the first in the standings.\r\nThere are only 5 rounds left in the championship and Barcelona's chances of catching up to first place are already minimal.\r\nFor the Catalans, it remains to fight for a trophy in the Champions League, where they will face a quarter-final match against a team from Paris Saint-Germain, and for the Copa del Rey in Spain, where they will play against a Sevilla team in the semi-finals.",
                PublishedOn = DateTime.Now.AddDays(-107),
                TeamId = Team1.Id,
                OwnerId = Publisher2.Id,
                IsActive = true,
            };
            context.News.Add(News2);

            News3 = new News()
            {
                Title = "Real Madrid and Manchester City could not beat each other",
                ImageURL = "RealNews1.png",
                Content = "Real Madrid and Manchester City had a very spectacular and interesting match in their first leg of the quarter-finals of the Champions League, which ended in a 3-3 draw.\r\nAt the very beginning of the match, Manchester City took the lead with a goal by Bernardo Silva in the 2nd minute, but then Real Madrid scored two goals, the first of which was an own goal by Ruben Diaz in the 12th minute, and the second goal was by Rodrigo Goes in the 14th minute. However, City then turned the score around again with goals from Phil Foden in the 66th minute and Josko Guardiol in the 71st minute. And finally Federico Valverde scored for Real and that's how the final score was 3:3.\r\nThe second match between the two teams will be on April 17.",
                PublishedOn = DateTime.Now.AddDays(-27),
                TeamId = Team2.Id,
                OwnerId = Publisher2.Id,
                IsActive = true,
            };
            context.News.Add(News3);


            Category1 = new Category()
            {
                Name = "T-Shirt"
            };
            context.Categories.Add(Category1);

            Category2 = new Category()
            {
                Name = "Scarf"
            };
            context.Categories.Add(Category2);



            Product1 = new Product()
            {
                Name = "Barcelona T-Shirt",
                Description = "Original Barcelona t-shirt made of 100% breathable fabric.",
                ImageURL = "BarcaTShirt.png",
                Price = 34.99M,
                UnitsAvailable = 10,
                CategoryId = Category1.Id,
                TeamId = Team2.Id,
                IsActive = true,
            };
            context.Products.Add(Product1);
            User1.FavoriteProducts.Add(
                new ApplicationUserProduct()
                {
                    ProductId = Product1.Id
                });

            Product2 = new Product()
            {
                Name = "Barcelona Scarf",
                Description = "Original Barcelona scarf made of cotton and synthetic fabric.",
                ImageURL = "BarcaScarf.png",
                Price = 22.99M,
                UnitsAvailable = 10,
                CategoryId = Category2.Id,
                TeamId = Team1.Id,
                IsActive = true,
            };
            context.Products.Add(Product2);
            User1.FavoriteProducts.Add(
                new ApplicationUserProduct()
                {
                    ProductId = Product2.Id
                });


            //Add more entities



            context.SaveChanges();
        }
    }
}
