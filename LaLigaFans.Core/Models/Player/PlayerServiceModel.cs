namespace LaLigaFans.Core.Models.Player
{
    public class PlayerServiceModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string TeamName { get; set; } = null!;
    }
}
