using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Contracts.PlayerContracts;
using LaLigaFans.Core.Models.Player;
using LaLigaFans.Core.Services.OtherServices;
using LaLigaFans.Core.Services.PlayerServices;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using LaLigaFans.Infrastructure.Data.Models;

namespace LaLigaFans.UnitTests.UnitTests
{
    [TestFixture]
    public class PlayerServiceTests : UnitTestsBase
    {
        private IUploadService uploadService;

        private IPlayerService playerService;

        [OneTimeSetUp]
        public void SetUp()
        {
            uploadService = new UploadService();
            playerService = new PlayerService(repository, uploadService);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue_WhitValidId()
        {
            var result = await playerService.ExistsAsync(Player1.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task AllPlayersByTeamIdAsync_ShouldReturnCorrectResult_WithValidTeamId()
        {
            var players = await playerService.AllPlayersByTeamIdAsync(Team2.Id);

            var contextPlayers = context.Players
                .Where(p => p.TeamId == Team2.Id);

            Assert.That(players.TotalPlayersCount, Is.EqualTo(contextPlayers.Count()));

            var player = players.Players
                .FirstOrDefault(p => p.Id == Player2.Id);

            Assert.That(player, Is.Not.Null);

            var contextPlayer = contextPlayers.FirstOrDefault(p => p.Id == Player2.Id);

            Assert.That(contextPlayer, Is.Not.Null);


            Assert.That(player.FirstName, Is.EqualTo(contextPlayer.FirstName));
            Assert.That(player.LastName, Is.EqualTo(contextPlayer.LastName));
            Assert.That(player.Age, Is.EqualTo(contextPlayer.Age));
        }

        [Test]
        public async Task CreateAsync_ShouldCreatePlayer()
        {
            var playersBefore = context.Players.Count();

            //Create fake IFormFile for test upload service
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);


            var newPlayer = new TeamPlayerAddFormModel()
            {
                FirstName = "Player2",
                LastName = "Playerov2",
                Age = 22,
                TeamId = Team2.Id,
                Image = file
            };

            var newPlayerId = await playerService.CreateAsync(newPlayer);

            var playersAfter= context.Players.Count();

            Assert.That(playersAfter, Is.EqualTo(playersBefore + 1));

            var newPlayerInDb = context.Players
                .Where(p => p.Id == newPlayerId).FirstOrDefault();

            Assert.That(newPlayerInDb, Is.Not.Null);
            Assert.That(newPlayerInDb.FirstName, Is.EqualTo(newPlayer.FirstName));
            Assert.That(newPlayerInDb.LastName, Is.EqualTo(newPlayer.LastName));
            Assert.That(newPlayerInDb.Age, Is.EqualTo(newPlayer.Age));

        }

        [Test]
        public async Task GetPlayerEditFormModelByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var playerForEdit = await playerService.GetPlayerEditFormModelByIdAsync(Player1.Id);

            Assert.That(playerForEdit, Is.Not.Null);
            Assert.That(playerForEdit.FirstName, Is.EqualTo(Player1.FirstName));
            Assert.That(playerForEdit.LastName, Is.EqualTo(Player1.LastName));
            Assert.That(playerForEdit.Age, Is.EqualTo(Player1.Age));
            Assert.That(playerForEdit.TeamId, Is.EqualTo(Player1.TeamId));
        }

        [Test]
        public async Task EditAsync_ShouldEditPlayerCorrectly()
        {
            var player = new Player()
            {
                FirstName = "TestPlayer",
                LastName = "TestPlayerov",
                Age = 33,
                PlayerImageUrl = "TestPlayer.png",
                TeamId = Team2.Id,
                IsActive = true,
            };

            await context.Players.AddAsync(player);
            await context.SaveChangesAsync();

            var changedFirstName = "EditedPlayer";
            var changedLastName = "EditedPlayerov";

            var playerEditFormModel = new PlayerEditFormModel()
            {
                FirstName = changedFirstName,
                LastName = changedLastName,
                Age = player.Age,
                Image = null,
                TeamId = Team2.Id
            };

            await playerService.EditAsync(player.Id, playerEditFormModel);

            var newPlayerInDb = await context.Players
                .FindAsync(player.Id);

            Assert.That(newPlayerInDb, Is.Not.Null);
            Assert.That(newPlayerInDb.FirstName, Is.EqualTo(changedFirstName));
            Assert.That(newPlayerInDb.LastName, Is.EqualTo(changedLastName));
            Assert.That(newPlayerInDb.Age, Is.EqualTo(player.Age));
        }

        [Test]
        public async Task DeleteAsync_ShouldChangeIsActivePropertyToFalse_WithValidId()
        {
            var player = new Player()
            {
                FirstName = "PlayerDelete",
                LastName = "PlayerDeletetov",
                Age = 33,
                PlayerImageUrl = "DellPlayer.png",
                TeamId = Team2.Id,
                IsActive = true,
            };

            await context.Players.AddAsync(player);
            await context.SaveChangesAsync();

            await playerService.DeleteAsync(player.Id);

            Assert.That(player.IsActive, Is.EqualTo(false));
        }

        [Test]
        public async Task GetPlayerDeleteServiceModelByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var playerForDelete = await playerService.GetPlayerDeleteServiceModelByIdAsync(Player1.Id);

            Assert.That(playerForDelete, Is.Not.Null);
            Assert.That(playerForDelete.FirstName, Is.EqualTo(Player1.FirstName));
            Assert.That(playerForDelete.LastName, Is.EqualTo(Player1.LastName));
            Assert.That(playerForDelete.Age, Is.EqualTo(Player1.Age));
            Assert.That(playerForDelete.TeamId, Is.EqualTo(Player1.TeamId));
        }



    }
}
