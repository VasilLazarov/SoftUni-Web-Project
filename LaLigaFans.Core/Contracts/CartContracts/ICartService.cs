using LaLigaFans.Core.Models.Cart;

namespace LaLigaFans.Core.Contracts.CartContracts
{
    public interface ICartService
    {
        Task CreateAsync(string userId);

        Task<CartServiceModel?> LoadAsync(string userId);

        Task<bool> ExistsAsync(int cartId);

        Task ClearCartAsync(int cartId);
    }
}
