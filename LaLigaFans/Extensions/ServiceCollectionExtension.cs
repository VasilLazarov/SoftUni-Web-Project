using LaLigaFans.Core.Contracts.CartServices;
using LaLigaFans.Core.Services.CartServices;
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
            //Add services to IoC conteiner
            services.AddScoped<ICartService, CartService>();



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
