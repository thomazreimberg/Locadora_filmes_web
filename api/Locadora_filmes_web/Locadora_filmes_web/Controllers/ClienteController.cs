using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Dtos;
using Locadora_filmes_web.Dtos.Cliente;
using Locadora_filmes_web.Service.Services;
using Microsoft.AspNetCore.Cors;
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
        public ClienteController()
        {
            _clienteService = new ClienteService();
        }

        /// <summary>
        /// Listagem de clientes.
        /// </summary>
        /// <returns>200: Lista de clientes. 400</returns>
        [HttpGet]
        public ActionResult<List<ClienteDtoConsulta>> ObterTodos() =>
            Ok(ConvertModel(_clienteService.ObterTodos()));

        /// <summary>
        /// Listagem de clientes por descrição.
        /// </summary>
        /// <returns>200: Lista de clientes. 400</returns>
        [HttpGet("Descricao")]
        public ActionResult<List<DescricaoDto>> ObterTodosPorDescricao() =>
            Ok(ConvertModelDescricao(_clienteService.ObterTodos()));

        /// <summary>-
        /// Consulta de cliente por ID.
        /// </summary>
        /// <param name="id">Id do cliente.</param>
        /// <returns>200: Cliente referente ao ID informado; 400</returns>
        [HttpGet("{id}")]
        public ActionResult<ClienteDtoConsulta> ObterPorId(int id) =>
            Ok(_clienteService.ObterPorId(id));

        /// <summary>
        /// Cadastro de cliente.
        /// </summary>
        /// <param name="cliente">Dados do cliente para cadastro.</param>
        /// <returns>200: Id do novo clientes; 400: Mensagem de validação.</returns>
        [HttpPost]
        public ActionResult<RetornoInclusaoRegistroDto> Incluir([FromBody] ClienteDto cliente) =>
            Ok(new RetornoInclusaoRegistroDto()
            {
                Id = _clienteService.Incluir(
                new Cliente()
                {
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    DataNascimento = cliente.DataNascimento
                })
            });

        /// <summary>
        /// Alteração no cadastro de cliente.
        /// </summary>
        /// <param name="id">Id do clientes a ser alterado.</param>
        /// <param name="cliente">Novos dados do clientes.</param>
        /// <returns>200; 400: Mensagem de validação.</returns>
        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] ClienteDto cliente)
        {
            _clienteService.Alterar(id, new Cliente()
            {
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento.Date
            });

            return Ok();
        }

        /// <summary>
        /// Exclui clientes.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            _clienteService.Excluir(id);
            return Ok();
        }

        private List<ClienteDtoConsulta> ConvertModel(List<Cliente> clientes)
        {
            var clienteDto = new List<ClienteDtoConsulta>();
            foreach (var item in clientes)
            {
                clienteDto.Add(new ClienteDtoConsulta() 
                { 
                    Key = item.Id,
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    DataNascimento = item.DataNascimento,
                });
            }

            return clienteDto;
        }

        private List<DescricaoDto> ConvertModelDescricao(List<Cliente> clientes)
        {
            var clienteDto = new List<DescricaoDto>();
            foreach (var item in clientes)
            {
                clienteDto.Add(new DescricaoDto()
                {
                    Key = item.Id,
                    Descricao = item.Nome,
                });
            }

            return clienteDto;
        }
    }
}
