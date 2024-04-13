namespace LaLigaFans.Core.Models.Team
{
    public class TeamsQueryServiceModel
    {
        public int TotalTeamsCount { get; set; }

        public IEnumerable<TeamServiceModel> Teams { get; set; }
            = new List<TeamServiceModel>();
    }
}
