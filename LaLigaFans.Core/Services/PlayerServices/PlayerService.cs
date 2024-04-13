using LaLigaFans.Core.Contracts.PlayerContracts;
using LaLigaFans.Core.Models.Player;
using LaLigaFans.Core.Models.Team;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.Core.Services.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repository;

        public PlayerService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<PlayersQueryServiceModel> AllPlayersByTeamIdAsync(
            int id,
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var players = await repository.AllReadOnly<Player>()
                .Where(p => p.TeamId == id)
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(p => new PlayerServiceModel()
                {
                    Id = p.Id,
                    FirstName =p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age,
                    ImageUrl = p.PlayerImageUrl,
                    TeamName = p.Team.Name
                })
                .ToListAsync();

            var totaPlayers = await repository.AllReadOnly<Player>()
                .Where(p => p.TeamId == id)
                .CountAsync();

            var playersAndCount = new PlayersQueryServiceModel()
            {
                Players = players,
                TotalPlayersCount = totaPlayers
            };

            return playersAndCount;
        }

    }
}
