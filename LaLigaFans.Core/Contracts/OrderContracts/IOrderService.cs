using LaLigaFans.Core.Models.Order;
using LaLigaFans.Infrastructure.Enums;

namespace LaLigaFans.Core.Contracts.OrderContracts
{
    public interface IOrderService
    {
        Task<OrderFormModel> GetOrderFromModelWithProductsAsync(int cartId);

        Task<int> CreatePaymentAsync(decimal totalPrice, PaymentMethod paymentMethod);

        Task<int> CreateAddressAsync(string city, string streetEtc);

        Task CreateOrderAsync(int cartId, string userId, int paymentId, int addressId);

        Task<IEnumerable<OrderServiceModel>> GetOrdersByUserIdAsync(string userId);

        Task<bool> ExistsAsync(int orderId);

        Task<OrderServiceModel?> GetOrderDetailsByIdAsync(int orderId);
    }
}
