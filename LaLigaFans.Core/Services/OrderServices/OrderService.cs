using LaLigaFans.Core.Contracts.OrderContracts;
using LaLigaFans.Core.Models.Cart;
using LaLigaFans.Core.Models.Order;
using LaLigaFans.Core.Models.Products;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using LaLigaFans.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LaLigaFans.Core.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;

        public OrderService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<OrderFormModel> GetOrderFromModelWithProducts(int cartId)
        {
            var products = await repository.AllReadOnly<CartProduct>()
                .Where(c => c.CartId == cartId)
                .Select(c => new ProductServiceModel()
                {
                    Id = c.ProductId,
                    Name = c.Product.Name,
                    Price = c.Product.Price,
                    ImageUrl = c.Product.ImageURL
                })
                .ToListAsync();

            var orderModel = new OrderFormModel()
            {
                Products = products,
                TotalPrice = products.Sum(p => p.Price),
                CartId = cartId
            };

            return orderModel;
        }


        public async Task<int> CreatePayment(decimal totalPrice, PaymentMethod paymentMethod)
        {
            var payment = new Payment()
            {
                PaymentMethod = paymentMethod,
                TotalPrice = totalPrice
            };

            await repository.AddAsync(payment);
            await repository.SaveChangesAsync();

            return payment.Id;
        }

        public async Task<int> CreateAddress(string city, string streetEtc)
        {
            var address = new Address() 
            { 
                City = city,
                StreetEtc = streetEtc
            };

            await repository.AddAsync(address);
            await repository.SaveChangesAsync();

            return address.Id;
        }

        public async Task CreateOrder(int cartId, string userId, int paymentId, int addressId)
        {
            var products = await repository.All<CartProduct>()
                .Where(c => c.CartId == cartId)
                .Include(c => c.Product)
                .ToListAsync();

            var order = new Order()
            {
                BuyerId = userId,
                AddressId = addressId,
                PaymentId = paymentId
            };

            foreach (var product in products)
            {
                product.Product.UnitsAvailable -= 1;
                var orderProduct = new OrderProduct()
                {
                    ProductId = product.Product.Id
                };
                order.OrdersProducts.Add(orderProduct);

            }

            await repository.AddAsync(order);
            await repository.SaveChangesAsync();
        }

    }
}
