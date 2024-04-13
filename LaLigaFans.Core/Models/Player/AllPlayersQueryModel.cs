namespace LaLigaFans.Core.Models.Player
{
    public class AllPlayersQueryModel
    {
        public const int PlayersPerPage = 4;

        public int CurrentPage { get; set; } = 1;

        public int TotalPlayersCount { get; set; }

        public string TeamName { get; set; } = null!;

        public IEnumerable<PlayerServiceModel> Players { get; set; }
            = new List<PlayerServiceModel>();
    }
}
