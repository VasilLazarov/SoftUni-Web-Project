using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Team;
using LaLigaFans.Core.Services.OtherServices;
using LaLigaFans.Core.Services.TeamServices;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.UnitTests.UnitTests
{
    [TestFixture]
    public class TeamServiceTests : UnitTestsBase
    {
        private IUploadService uploadService;

        private ITeamService teamService;

        [OneTimeSetUp]
        public void SetUp()
        {
            uploadService = new UploadService();
            teamService = new TeamService(repository, uploadService);
        }

        [Test]
        public async Task AllAsync_ShouldReturnCorrectResult()
        {
            var teams = await teamService.AllAsync();

            var contextTeams = await context.Teams.ToListAsync();

            Assert.That(teams.TotalTeamsCount, Is.EqualTo(contextTeams.Count()));

            var tems = teams.Teams
                .FirstOrDefault(t => t.Id == Team1.Id);

            Assert.That(tems, Is.Not.Null);

            Assert.That(tems.Name, Is.EqualTo(Team1.Name));
            Assert.That(tems.CoachName, Is.EqualTo(Team1.CoachName));
            Assert.That(tems.FoundedYear, Is.EqualTo(Team1.FoundedYear));
        }

        [Test]
        public async Task IsFollowedByUserWithIdAsync_ShouldReturnTrue_WithValidIds()
        {
            bool result = await teamService.IsFollowedByUserWithIdAsync(Team1.Id, User1.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TeamDetailsByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var team = await teamService.TeamDetailsByIdAsync(Team1.Id);

            Assert.That(team, Is.Not.Null);
            Assert.That(team.Name, Is.EqualTo(Team1.Name));
            Assert.That(team.CoachName, Is.EqualTo(Team1.CoachName));
            Assert.That(team.FoundedYear, Is.EqualTo(Team1.FoundedYear));
            Assert.That(team.LogoUrl, Is.EqualTo(Team1.LogoUrl));
            Assert.That(team.Information, Is.EqualTo(Team1.Information));
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue_WhitValidId()
        {
            var result = await teamService.ExistsAsync(Team1.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task FollowAsync_ShouldReturnTrue_WithValidIds()
        {
            var newTeam = new Team()
            {
                Name = "TeamForFollow",
                CoachName = "CoachName",
                FoundedYear = 2005,
                IsActive = true,
                Information = "Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.",
                LogoUrl = "TeamLogo.png"
            };

            await context.Teams.AddAsync(newTeam);
            await context.SaveChangesAsync();

            await teamService.FollowAsync(newTeam.Id, User1.Id);

            var newTeamInDb = await context.Teams
                .FirstOrDefaultAsync(t => t.Id == newTeam.Id);

            Assert.That(newTeamInDb, Is.Not.Null);

            bool followedNewTeam = newTeamInDb.Followers
                .Any(f => f.ApplicationUserId == User1.Id);

            Assert.That(followedNewTeam, Is.True);
        }

        [Test]
        public async Task UnfollowAsync_ShouldReturnFalse_WithValidIds()
        {
            var newTeam = new Team()
            {
                Name = "TeamForFollow",
                CoachName = "CoachName",
                FoundedYear = 2005,
                IsActive = true,
                Information = "Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.",
                LogoUrl = "TeamLogo.png"
            };

            await context.Teams.AddAsync(newTeam);

            newTeam.Followers.Add(
                new ApplicationUserTeam()
                {
                    ApplicationUserId = User1.Id
                });

            await context.SaveChangesAsync();

            await teamService.UnfollowAsync(newTeam.Id, User1.Id);

            var newTeamInDb = await context.Teams
                .FirstOrDefaultAsync(t => t.Id == newTeam.Id);

            Assert.That(newTeamInDb, Is.Not.Null);

            bool unfollowNewTeam = newTeamInDb.Followers
                .Any(f => f.ApplicationUserId == User1.Id);

            Assert.That(unfollowNewTeam, Is.False);
        }

        [Test]
        public async Task Followed_ShouldReturnCorrectData_WithValidUserId()
        {
            var user1FollowedTeams = await teamService.FollowedAsync(User1.Id);

            var user1InDbFT = await context.Teams
                .Where(t => t.Followers.Any(f => f.ApplicationUserId == User1.Id))
                .ToListAsync();

            Assert.That(user1FollowedTeams.TotalTeamsCount, Is.EqualTo(user1InDbFT.Count()));
        }

        [Test]
        public async Task CreateAsync_ShouldCreateTeam()
        {
            var teamsCountBefore = context.Teams.Count();

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


            var newTeam = new TeamAddFormModel()
            {
                Name = "AddedTeam",
                ImageLogo = file,
                FoundedYear = 2002,
                CoachName = "NewCoachName",
                Information = "Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information."
            };

            var newTeamId = await teamService.CreateAsync(newTeam);

            var teamsCountAfter = context.Teams.Count();

            Assert.That(teamsCountAfter, Is.EqualTo(teamsCountBefore + 1));

            await context.SaveChangesAsync();

            var newTeamInDb = context.Teams
                .Where(t => t.Id == newTeamId).FirstOrDefault();

            Assert.That(newTeamInDb, Is.Not.Null);
            Assert.That(newTeamInDb.Name, Is.EqualTo(newTeam.Name));
            Assert.That(newTeamInDb.FoundedYear, Is.EqualTo(newTeam.FoundedYear));
            Assert.That(newTeamInDb.CoachName, Is.EqualTo(newTeam.CoachName));
            Assert.That(newTeamInDb.Information, Is.EqualTo(newTeam.Information));
        }

        [Test]
        public async Task EditAsync_ShouldEditTeamCorrectly()
        {
            var team = new Team()
            {
                Name = "AddedTeam",
                LogoUrl = "AddedTeamLogo.png",
                FoundedYear = 2002,
                CoachName = "NewCoachName",
                Information = "Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.",
                IsActive = true,
            };

            await context.Teams.AddAsync(team);
            await context.SaveChangesAsync();

            var changedName = "EditedTeamName";
            var changedCoachName = "EditedCoachName";

            var teamEditFormModel = new TeamEditFormModel()
            {
                Name = changedName,
                ImageLogo = null,
                FoundedYear = team.FoundedYear,
                CoachName = changedCoachName,
                Information = team.Information
            };

            await teamService.EditAsync(team.Id, teamEditFormModel);

            var newTeamInDb = await context.Teams
                .FindAsync(team.Id);

            Assert.That(newTeamInDb, Is.Not.Null);
            Assert.That(newTeamInDb.Name, Is.EqualTo(changedName));
            Assert.That(newTeamInDb.CoachName, Is.EqualTo(changedCoachName));
            Assert.That(newTeamInDb.FoundedYear, Is.EqualTo(team.FoundedYear));
            Assert.That(newTeamInDb.Information, Is.EqualTo(team.Information));
        }

        [Test]
        public async Task GetTeamEditFormModelByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var teamForEdit = await teamService.GetTeamEditFormModelByIdAsync(Team1.Id);

            Assert.That(teamForEdit, Is.Not.Null);
            Assert.That(teamForEdit.Name, Is.EqualTo(Team1.Name));
            Assert.That(teamForEdit.FoundedYear, Is.EqualTo(Team1.FoundedYear));
            Assert.That(teamForEdit.CoachName, Is.EqualTo(Team1.CoachName));
            Assert.That(teamForEdit.Information, Is.EqualTo(Team1.Information));
        }

        [Test]
        public async Task GetTeamIdsAndNames_ShouldReturnCorrectData()
        {
            var teamIdsAndNames = await teamService.GetTeamIdsAndNames();

            Assert.That(teamIdsAndNames, Is.Not.Null);

            var teamIdAndNameForTeam1 = teamIdsAndNames
                .FirstOrDefault(t => t.Id == Team1.Id);

            Assert.That(teamIdAndNameForTeam1, Is.Not.Null);

            Assert.That(teamIdAndNameForTeam1.Name, Is.EqualTo(Team1.Name));
        }

        [Test]
        public async Task AllTeamNamesAsync_ShouldReturnCorrectData()
        {
            var teamNames = await teamService.AllTeamNamesAsync();

            Assert.That(teamNames, Is.Not.Null);

            var teamCount = await context.Teams.CountAsync();

            Assert.That(teamNames.Count(), Is.EqualTo(teamCount));
        }

        [Test]
        public async Task DeleteAsync_ShouldChangeIsActivePropertyToFalse_WithValidId()
        {
            var team = new Team()
            {
                Name = "AddedTeam",
                LogoUrl = "AddedTeamLogo.png",
                FoundedYear = 2002,
                CoachName = "NewCoachName",
                Information = "Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.Team3 information.",
                IsActive = true,
            };

            await context.Teams.AddAsync(team);
            await context.SaveChangesAsync();

            await teamService.DeleteAsync(team.Id);

            Assert.That(team.IsActive, Is.EqualTo(false));
        }

        [Test]
        public async Task GetTeamDeleteServiceModelByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var teamForDelete = await teamService.GetTeamDeleteServiceModelByIdAsync(Team1.Id);

            Assert.That(teamForDelete, Is.Not.Null);
            Assert.That(teamForDelete.Name, Is.EqualTo(Team1.Name));
            Assert.That(teamForDelete.CoachName, Is.EqualTo(Team1.CoachName));
            Assert.That(teamForDelete.FoundedYear, Is.EqualTo(Team1.FoundedYear));
            Assert.That(teamForDelete.Information, Is.EqualTo(Team1.Information));
            Assert.That(teamForDelete.LogoUrl, Is.EqualTo(Team1.LogoUrl));
        }

    }
}
