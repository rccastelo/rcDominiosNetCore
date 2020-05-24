using Microsoft.AspNetCore.Mvc;

namespace rcDominiosWeb.Controllers
{
    public class DominiosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
