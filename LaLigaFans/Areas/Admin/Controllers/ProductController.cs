using LaLigaFans.Core.Contracts.ProductContracts;
using Microsoft.AspNetCore.Mvc;
using LaLigaFans.Core.Models.Products;
using LaLigaFans.Core.Contracts.TeamContracts;
using static LaLigaFans.Core.Constants.MessageConstants;
using Microsoft.AspNetCore.Identity;

namespace LaLigaFans.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ProductAddFormModel()
            {
                Teams = await teamService.GetTeamIdsAndNames(),
                Categories = await productService.GetCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddFormModel model)
        {
            if (await teamService.ExistsAsync(model.TeamId) == false)
            {
                ModelState.AddModelError(nameof(model.TeamId), TeamErrorMessage);
            }

            if (await productService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), CategoryErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Teams = await teamService.GetTeamIdsAndNames();
                model.Categories = await productService.GetCategoriesAsync();
                return View(model);
            }

            int newProductId = await productService.CreateAsync(model);

            return RedirectToAction("Details", "Product", new { area = "", id = newProductId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var productModel = await productService.GetProductEditFormModelByIdAsync(id);

            if(productModel != null)
            {
                productModel.Teams = await teamService.GetTeamIdsAndNames();
                productModel.Categories = await productService.GetCategoriesAsync();
            }

            return View(productModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductEditFormModel model)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await teamService.ExistsAsync(model.TeamId) == false)
            {
                ModelState.AddModelError(nameof(model.TeamId), TeamErrorMessage);
            }

            if (await productService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), CategoryErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Teams = await teamService.GetTeamIdsAndNames();
                model.Categories = await productService.GetCategoriesAsync();
                return View(model);
            }

            await productService.EditAsync(id, model);

            return RedirectToAction("Details", "Product", new { area = "", id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var productModel = await productService.GetProductDeleteServiceModelByIdAsync(id);

            return View(productModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteServiceModel model)
        {
            if (await productService.ExistAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await productService.DeleteAsync(model.Id);

            return RedirectToAction("All", "Product", new { area = "" });
        }


    }
}
