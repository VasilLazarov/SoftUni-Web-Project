using Microsoft.AspNetCore.Mvc;

namespace LaLigaFans.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
