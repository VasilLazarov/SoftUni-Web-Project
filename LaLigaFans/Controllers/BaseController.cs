using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaFans.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
