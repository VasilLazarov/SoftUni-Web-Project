using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LaLigaFans.Core.Constants.RoleNamesConstants;

namespace LaLigaFans.Controllers
{
    [Authorize(Roles = UserRoleName)]
    public class BaseController : Controller
    {

    }
}
