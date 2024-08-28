using LaLigaFans.Core.Contracts.UserContracts;
using LaLigaFans.Core.Models.User;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static LaLigaFans.Core.Constants.RoleNamesConstants;

namespace LaLigaFans.Core.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;


        public UserService(
            IRepository _repository,
            UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            var users = await repository.AllReadOnly<ApplicationUser>()
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    OrdersCount = u.Orders.Count
                })
                .ToListAsync();

            foreach (var user in users)
            {
                var appUser = await userManager.FindByEmailAsync(user.Email);
                user.IsPublisher = await userManager.IsInRoleAsync(appUser, PublisherRoleName);
            }

            return users;
        }


        public async Task AddToUserRolePublisherAsync(string userEmail)
        {
            var appUser = await userManager.FindByEmailAsync(userEmail);

            await userManager.AddToRoleAsync(appUser, PublisherRoleName);
        }

        public async Task RemoveFromUserRolePublisherAsync(string userEmail)
        {
            var appUser = await userManager.FindByEmailAsync(userEmail);

            await userManager.RemoveFromRoleAsync(appUser, PublisherRoleName);
        }

    }
}
