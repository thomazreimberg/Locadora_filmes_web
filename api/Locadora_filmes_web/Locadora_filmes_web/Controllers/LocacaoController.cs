using Microsoft.AspNetCore.Mvc;

namespace Locadora_filmes_web.Controllers
{
    public class LocacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
