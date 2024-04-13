using LaLigaFans.Core.Contracts.CartContracts;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;

namespace LaLigaFans.Core.Services.CartServices
{
    public class CartService : ICartService
    {
        private readonly IRepository repository;

        public CartService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId)
        {
            var cart = new Cart()
            {
                ApplicationUserId = userId
            };

            await repository.AddAsync(cart);
            await repository.SaveChangesAsync();
        }
    }
}
