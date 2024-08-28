using LaLigaFans.Core.Contracts.CartContracts;
using LaLigaFans.Core.Contracts.CommentContracts;
using LaLigaFans.Core.Contracts.NewsContracts;
using LaLigaFans.Core.Contracts.OrderContracts;
using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Contracts.PlayerContracts;
using LaLigaFans.Core.Contracts.ProductContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Contracts.UserContracts;
using LaLigaFans.Core.Services.CartServices;
using LaLigaFans.Core.Services.CommentServices;
using LaLigaFans.Core.Services.NewsServices;
using LaLigaFans.Core.Services.OrderServices;
using LaLigaFans.Core.Services.OtherServices;
using LaLigaFans.Core.Services.PlayerServices;
using LaLigaFans.Core.Services.ProductServices;
using LaLigaFans.Core.Services.TeamServices;
using LaLigaFans.Core.Services.UserServices;
using LaLigaFans.Infrastructure.Data;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();

            services.AddScoped<ITeamService, TeamService>();

            services.AddScoped<IPlayerService, PlayerService>();

            services.AddScoped<IUploadService, UploadService>();

            services.AddScoped<INewsService, NewsService>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IUserService, UserService>();


            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<LaLigaFansDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 10;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<LaLigaFansDbContext>();

            return services;
        }
    }
}
