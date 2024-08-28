using LaLigaFans.Core.Contracts.CartContracts;
using LaLigaFans.Core.Contracts.OrderContracts;
using LaLigaFans.Core.Models.Order;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaLigaFans.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        private readonly ICartService cartService;

        public OrderController(
            IOrderService _orderService,
            ICartService _cartService)
        {
            orderService = _orderService;
            cartService = _cartService;
        }


        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            if (await cartService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var orderModel = await orderService.GetOrderFromModelWithProductsAsync(id);

            return View(orderModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderFormModel model)
        {
            if (await cartService.ExistsAsync(model.CartId) == false)
            {
                return BadRequest();
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int paymentId = await orderService.CreatePaymentAsync(model.TotalPrice, model.PaymentMethod);

            int addressId = await orderService.CreateAddressAsync(model.City, model.StreetEtc);

            string userId = User.Id();

            await orderService.CreateOrderAsync(model.CartId, userId, paymentId, addressId);

            await cartService.ClearCartAsync(model.CartId);
            
            return RedirectToAction(nameof(Ordered));
        }

        [HttpGet]
        public async Task<IActionResult> Ordered()
        {
            string userId = User.Id();

            var orders = await orderService.GetOrdersByUserIdAsync(userId);

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await orderService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var order = await orderService.GetOrderDetailsByIdAsync(id);

            return View(order);
        }
    }
}
