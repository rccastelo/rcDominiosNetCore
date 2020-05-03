using Microsoft.AspNetCore.Mvc;

namespace rcDominiosWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
