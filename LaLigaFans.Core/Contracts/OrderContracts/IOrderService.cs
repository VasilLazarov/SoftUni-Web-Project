using LaLigaFans.Core.Models.Order;
using LaLigaFans.Infrastructure.Enums;

namespace LaLigaFans.Core.Contracts.OrderContracts
{
    public interface IOrderService
    {
        Task<OrderFormModel> GetOrderFromModelWithProducts(int cartId);

        Task<int> CreatePayment(decimal totalPrice, PaymentMethod paymentMethod);

        Task<int> CreateAddress(string city, string streetEtc);

        Task CreateOrder(int cartId, string userId, int paymentId, int addressId);
    }
}
