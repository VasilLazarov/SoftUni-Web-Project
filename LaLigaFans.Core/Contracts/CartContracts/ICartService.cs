using LaLigaFans.Core.Models.Cart;

namespace LaLigaFans.Core.Contracts.CartContracts
{
    public interface ICartService
    {
        Task CreateAsync(string userId);

        Task<CartServiceModel?> Load(string userId);

        Task<bool> ExistsAsync(int cartId);
    }
}
