using LaLigaFans.Core.Models.Team;

namespace LaLigaFans.Core.Models.Player
{
    public class PlayersQueryServiceModel
    {
        public int TotalPlayersCount { get; set; }

        public IEnumerable<PlayerServiceModel> Players { get; set; }
            = new List<PlayerServiceModel>();
    }
}
