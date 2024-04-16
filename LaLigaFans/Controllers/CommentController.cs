using LaLigaFans.Core.Contracts.CommentContracts;
using LaLigaFans.Core.Contracts.NewsContracts;
using LaLigaFans.Core.Contracts.ProductContracts;
using LaLigaFans.Core.Models.Comment;
using LaLigaFans.Core.Models.News;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaLigaFans.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;

        private readonly INewsService newsService;

        private readonly IProductService productService;

        public CommentController(
            ICommentService _commentService,
            INewsService _newsService,
            IProductService _productService)
        {
            commentService = _commentService;
            newsService = _newsService;
            productService = _productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToNews(int id, CommentFormModel model)
        {
            if (await newsService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "News", new { id = id });
            }

            var userId = User.Id();
            await commentService.CreateNewsCommentAsync(id, userId, model.Title, model.Content);

            return RedirectToAction("Details", "News", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddToProduct(int id, CommentFormModel model)
        {

            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Product", new { id = id });
            }

            var userId = User.Id();
            await commentService.CreateProductCommentAsync(id, userId, model);

            return RedirectToAction("Details", "Product", new { id = id });
        }
    }
}
