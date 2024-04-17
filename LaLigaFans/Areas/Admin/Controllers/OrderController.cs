using LaLigaFans.Core.Contracts.OrderContracts;
using LaLigaFans.Core.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaLigaFans.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var orders = await orderService.GetAllOrders();

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
