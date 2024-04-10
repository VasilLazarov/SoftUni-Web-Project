using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LaLigaFans.Infrastructure.Constants.AdminConstants;

namespace LaLigaFans.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminBaseController : Controller
    {

    }
}
