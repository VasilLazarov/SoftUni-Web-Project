using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaFans.Controllers
{
    [Authorize(Roles = "User")]
    public class BaseController : Controller
    {

    }
}
