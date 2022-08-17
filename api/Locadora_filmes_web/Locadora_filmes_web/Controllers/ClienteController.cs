using Locadora_filmes_web.Dtos.Cliente;
using Locadora_filmes_web.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Locadora_filmes_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private ClienteService _clienteService { get; set; }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="clienteService">Interface que implementa as funções para as rotas de cor.</param>
        public ClienteController()
        {
            _clienteService = new ClienteService();
        }

        /// <summary>
        /// Listagem de clientes.
        /// </summary>
        /// <returns>200: Lista de clientes. 400</returns>
        [HttpGet]
        public ActionResult<List<ClienteDtoConsulta>> Get() =>
            Ok(_clienteService.ObterTodos());
    }
}
