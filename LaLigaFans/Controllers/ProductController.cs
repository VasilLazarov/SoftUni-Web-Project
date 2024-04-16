using LaLigaFans.Core.Contracts.ProductContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Products;
using LaLigaFans.Core.Models.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaLigaFans.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        private readonly ITeamService teamService;

        public ProductController(
            IProductService _productService,
            ITeamService _teamService)
        {
            productService = _productService;
            teamService = _teamService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel query)
        {
            var userId = User.Id();

            var queryResult = await productService.AllAsync(
                userId,
                query.Category,
                query.Team,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllProductsQueryModel.ProductsPerPage);

            query.TotalProductCount = queryResult.TotalProductCount;
            query.Products = queryResult.Products;

            var categoriesNames = await productService.AllCategoriesNamesAsync();
            query.Categories = categoriesNames;

            var teamNames = await teamService.AllTeamNamesAsync();
            query.Teams = teamNames;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var productModel = await productService.ProductDetailsByIdAsync(id);
            productModel.CommentForm = new CommentFormModel()
            {
                CommentObjectId = id
            };

            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> Favorites([FromQuery] FavoriteProductsQueryModel query)
        {
            var userId = User.Id();

            var queryResult = await productService.FavoritesAsync(
                userId,
                query.CurrentPage,
                FavoriteProductsQueryModel.ProductsPerPage);

            query.TotalProductsCount = queryResult.TotalProductCount;
            query.Products = queryResult.Products;

            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = User.Id();

            if (await productService.IsFavoriteOfUserWithIdAsync(id, userId))
            {
                return BadRequest();
            }

            await productService.AddProductToFavoritesAsync(id, userId);

            return RedirectToAction(nameof(Favorites));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFavorite(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = User.Id();

            if (await productService.IsFavoriteOfUserWithIdAsync(id, userId) == false)
            {
                return BadRequest();
            }

            await productService.RemoveProductFromFavoritesAsync(id, userId);

            return RedirectToAction(nameof(Favorites));
        }

    }
}
