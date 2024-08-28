using LaLigaFans.Core.Contracts.UserContracts;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaFans.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await userService.AllAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AddPublisher(string userEmail)
        {
            await userService.AddToUserRolePublisherAsync(userEmail);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> RemovePublisher(string userEmail)
        {
            await userService.RemoveFromUserRolePublisherAsync(userEmail);

            return RedirectToAction(nameof(All));
        }
    }
}
