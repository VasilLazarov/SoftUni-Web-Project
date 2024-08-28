namespace LaLigaFans.Core.Models.News
{
    public class NewsQueryServiceModel
    {
        public int TotalNewsCount { get; set; }

        public IEnumerable<NewsServiceModel> News { get; set; }
            = new List<NewsServiceModel>();
    }
}
