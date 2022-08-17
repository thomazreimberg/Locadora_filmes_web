using Microsoft.AspNetCore.Mvc;

namespace Locadora_filmes_web.Controllers
{
    public class FilmeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
