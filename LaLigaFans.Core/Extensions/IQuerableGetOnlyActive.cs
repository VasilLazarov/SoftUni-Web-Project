using LaLigaFans.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableGetOnlyActive
    {
        public static IQueryable<Team> GetOnlyActiveTeams(this IQueryable<Team> teams)
        {
            var activeTeams = teams
                .Where(i => i.IsActive == true);

            return activeTeams;
        }

        public static IQueryable<Player> GetOnlyActivePlayers(this IQueryable<Player> players)
        {
            var activePlayers = players
                .Where(i => i.IsActive == true);

            return activePlayers;
        }

        public static IQueryable<News> GetOnlyActiveNews(this IQueryable<News> news)
        {
            var activeNews = news
                .Where(i => i.IsActive == true);

            return activeNews;
        }

        public static IQueryable<Product> GetOnlyActiveProducts(this IQueryable<Product> products)
        {
            var activeProducts = products
                .Where(i => i.IsActive == true);

            return activeProducts;
        }

        public static IQueryable<Comment> GetOnlyActiveComments(this IQueryable<Comment> comments)
        {
            var activeComments = comments
                .Where(i => i.IsActive == true);

            return activeComments;
        }
    }
}
