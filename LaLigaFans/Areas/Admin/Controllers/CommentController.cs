using LaLigaFans.Core.Contracts.CommentContracts;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaFans.Areas.Admin.Controllers
{
    public class CommentController : AdminBaseController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await commentService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var commentObjectInfo = await commentService.DeleteAsync(id);

            return RedirectToAction("Details", commentObjectInfo.ObjectType , new { area = "", id = commentObjectInfo.ObjectId });
        }
    }
}
