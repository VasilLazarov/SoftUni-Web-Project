using LaLigaFans.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableGetDeleted
    {
        public static IQueryable<Team> GetDeletedTeams(this IQueryable<Team> teams)
        {
            var deletedTeams = teams
                .Where(i => i.IsActive == false);

            return deletedTeams;
        }

        public static IQueryable<Player> GetDeletedPlayers(this IQueryable<Player> players)
        {
            var deletedPlayers = players
                .Where(i => i.IsActive == false);

            return deletedPlayers;
        }

        public static IQueryable<News> GetDeletedNews(this IQueryable<News> news)
        {
            var deletedNews = news
                .Where(i => i.IsActive == false);

            return deletedNews;
        }

        public static IQueryable<Product> GetDeletedProducts(this IQueryable<Product> products)
        {
            var deletedProducts = products
                .Where(i => i.IsActive == false);

            return deletedProducts;
        }

    }
}
