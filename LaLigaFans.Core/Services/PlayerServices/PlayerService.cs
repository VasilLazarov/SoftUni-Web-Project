using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Contracts.PlayerContracts;
using LaLigaFans.Core.Models.Player;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.Core.Services.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repository;
        private readonly IUploadService uploadService;

        public PlayerService(IRepository _repository,
            IUploadService _uploadService)
        {
            repository = _repository;
            uploadService = _uploadService;
        }

        public async Task<PlayersQueryServiceModel> AllPlayersByTeamIdAsync(
            int id,
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var players = await repository.AllReadOnly<Player>()
                .GetOnlyActivePlayers()
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

        public async Task<bool> ExistsAsync(int id)
        {
            bool result = await repository.AllReadOnly<Player>()
                .GetOnlyActivePlayers()
                .AnyAsync(p => p.Id == id);

            return result;
        }

        public async Task<int> CreateAsync(PlayerAddFormModel model)
        {
            string imageUrl = model.Image.FileName;
            string folderName = "players";
            if (!await uploadService.UploadImage(model.Image, folderName))
            {
                imageUrl = "Default.png";
            }

            var player = new Player()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                PlayerImageUrl = imageUrl,
                TeamId = model.TeamId
            };

            await repository.AddAsync(player);
            await repository.SaveChangesAsync();

            return model.TeamId;
        }

        public async Task<PlayerEditFormModel?> GetPlayerEditFormModelByIdAsync(int playerId)
        {
            var playerModel = await repository.AllReadOnly<Player>()
                .GetOnlyActivePlayers()
                .Where(p => p.Id == playerId)
                .Select(p => new PlayerEditFormModel()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age,
                    TeamId = p.TeamId
                })
                .FirstOrDefaultAsync();

            return playerModel;
        }

        public async Task EditAsync(int playerId, PlayerEditFormModel model)
        {
            var player = await repository.GetByIdAsync<Player>(playerId);

            if(player != null)
            {
                player.FirstName = model.FirstName;
                player.LastName = model.LastName;
                player.Age = model.Age;
                player.TeamId = model.TeamId;
                
                if(model.Image != null)
                {
                    string imageUrl = model.Image.FileName;
                    string folderName = "players";
                    if (!await uploadService.UploadImage(model.Image, folderName))
                    {
                        imageUrl = "Default.png";
                    }
                    player.PlayerImageUrl = imageUrl;
                }

                await repository.SaveChangesAsync();
            }

        }

        public async Task DeleteAsync(int playerId)
        {
            var player = await repository.GetByIdAsync<Player>(playerId);
            
            if(player != null)
            {
                player.IsActive = false;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<PlayerDeleteServiceModel?> GetPlayerDeleteServiceModelByIdAsync(int playerId)
        {
            var playerModel = await repository.AllReadOnly<Player>()
                .GetOnlyActivePlayers()
                .Where(p => p.Id == playerId)
                .Select(p => new PlayerDeleteServiceModel()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age,
                    ImageUrl = p.PlayerImageUrl,
                    TeamName = p.Team.Name,
                    TeamId = p.Team.Id,
                })
                .FirstOrDefaultAsync();

            return playerModel;
        }



    }
}
