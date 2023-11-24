using Microsoft.AspNetCore.Mvc;

namespace Gestor.APP.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
