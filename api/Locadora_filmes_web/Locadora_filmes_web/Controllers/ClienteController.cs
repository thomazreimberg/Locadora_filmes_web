using Microsoft.AspNetCore.Mvc;

namespace Locadora_filmes_web.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
