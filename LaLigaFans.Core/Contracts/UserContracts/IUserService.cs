using LaLigaFans.Core.Models.User;

namespace LaLigaFans.Core.Contracts.UserContracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> AllAsync();

        Task AddToUserRolePublisherAsync(string userEmail);

        Task RemoveFromUserRolePublisherAsync(string userEmail);

    }
}
