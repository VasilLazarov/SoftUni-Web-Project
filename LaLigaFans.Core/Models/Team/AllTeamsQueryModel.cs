namespace LaLigaFans.Core.Models.Team
{
    public class AllTeamsQueryModel
    {
        public const int TeamsPerPage = 4;

        public int CurrentPage { get; set; } = 1;

        public int TotalTeamsCount { get; set; }

        public IEnumerable<TeamServiceModel> Teams { get; set; }
            = new List<TeamServiceModel>();

    }
}
