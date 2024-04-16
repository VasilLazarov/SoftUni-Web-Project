using LaLigaFans.Core.Contracts.CartContracts;
using LaLigaFans.Core.Models.Cart;
using LaLigaFans.Core.Models.Products;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CartServiceModel?> Load(string userId)
        {
            var cartModel = await repository.AllReadOnly<Cart>()
                .Where(c => c.ApplicationUserId == userId)
                .Select(c => new CartServiceModel()
                {
                    Id = c.Id,
                    Products = c.CartsProducts
                        .Select(cp => new ProductServiceModel()
                        {
                            Id = cp.Product.Id,
                            Name = cp.Product.Name,
                            Price = cp.Product.Price,
                            ImageUrl = cp.Product.ImageURL
                        })
                })
                .FirstOrDefaultAsync();

            if(cartModel != null)
            {
                cartModel.TotalPrice = cartModel.Products.Sum(p => p.Price);
            }

            return cartModel;
        }
        public async Task<bool> ExistsAsync(int cartId)
        {
            var result = await repository.AllReadOnly<Cart>()
                .AnyAsync(c => c.Id == cartId);

            return result;
        }


    }
}
