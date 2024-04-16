using LaLigaFans.Core.Contracts.CartContracts;
using LaLigaFans.Core.Contracts.ProductContracts;
using LaLigaFans.Core.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaLigaFans.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService cartService;

        private readonly IProductService productService;

        public CartController(
            ICartService _cartService,
            IProductService _productService)
        {
            cartService = _cartService;
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Load()
        {
            string userId = User.Id();
            var cart = await cartService.LoadAsync(userId);

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = User.Id();

            if (await productService.IsProductAddedToCart(id, userId) == false)
            {
                return BadRequest();
            }

            await productService.RemoveProductFromCartAsync(id, userId);

            return RedirectToAction(nameof(Load));
        }
    }
}
