using LaLigaFans.Core.Contracts.OrderContracts;
using LaLigaFans.Core.Models.Order;
using LaLigaFans.Core.Models.Products;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using LaLigaFans.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.Core.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;

        public OrderService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<OrderFormModel> GetOrderFromModelWithProductsAsync(int cartId)
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

        public async Task<int> CreatePaymentAsync(decimal totalPrice, PaymentMethod paymentMethod)
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

        public async Task<int> CreateAddressAsync(string city, string streetEtc)
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

        public async Task CreateOrderAsync(int cartId, string userId, int paymentId, int addressId)
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

        public async Task<IEnumerable<OrderServiceModel>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await repository.AllReadOnly<Order>()
                .Where(o => o.BuyerId == userId)
                .Include(o => o.OrdersProducts)
                .Select(o => new OrderServiceModel()
                {
                    Id = o.Id,
                    PaymentMethod = o.Payment.PaymentMethod,
                    TotalPrice = o.Payment.TotalPrice,
                    City = o.Address.City,
                    StreetEtc = o.Address.StreetEtc,
                    ProductsCount = o.OrdersProducts.Count(),
                    UserFullName = o.Buyer.FirstName + " " + o.Buyer.LastName
                })
                .ToListAsync();

            return orders;
        }

        public async Task<bool> ExistsAsync(int orderId)
        {
            var result = await repository.AllReadOnly<Order>()
                .AnyAsync(o => o.Id == orderId);

            return result;
        }

        public async Task<OrderServiceModel?> GetOrderDetailsByIdAsync(int orderId)
        {
            var orders = await repository.AllReadOnly<Order>()
                .Where(o => o.Id == orderId)
                .Include(o => o.OrdersProducts)
                .ThenInclude(op => op.Product)
                .Select(o => new OrderServiceModel()
                {
                    Id = o.Id,
                    PaymentMethod = o.Payment.PaymentMethod,
                    TotalPrice = o.Payment.TotalPrice,
                    City = o.Address.City,
                    StreetEtc = o.Address.StreetEtc,
                    ProductsCount = o.OrdersProducts.Count(),
                    UserFullName = o.Buyer.FirstName + " " + o.Buyer.LastName,
                    Products = o.OrdersProducts
                        .Select(op => new ProductServiceModel()
                        {
                            Id = op.ProductId,
                            ImageUrl = op.Product.ImageURL,
                            Name = op.Product.Name,
                            Price = op.Product.Price
                        })
                })
                .FirstOrDefaultAsync();

            return orders;
        }

        public async Task<IEnumerable<OrderServiceModel>> GetAllOrders()
        {
            var orders = await repository.AllReadOnly<Order>()
                .Include(o => o.OrdersProducts)
                .Select(o => new OrderServiceModel()
                {
                    Id = o.Id,
                    PaymentMethod = o.Payment.PaymentMethod,
                    TotalPrice = o.Payment.TotalPrice,
                    City = o.Address.City,
                    StreetEtc = o.Address.StreetEtc,
                    ProductsCount = o.OrdersProducts.Count(),
                    UserFullName = o.Buyer.FirstName + " " + o.Buyer.LastName
                })
                .ToListAsync();

            return orders;
        }


    }
}
