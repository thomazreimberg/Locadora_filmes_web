using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Dtos;
using Locadora_filmes_web.Dtos.Locacao;
using Locadora_filmes_web.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Locadora_filmes_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : Controller
    {
        private LocacaoService _locacaoService { get; set; }
        private FilmeService _filmeService { get; set; }
        private ClienteService _clienteService { get; set; }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public LocacaoController()
        {
            _locacaoService = new LocacaoService();
            _filmeService = new FilmeService();
            _clienteService = new ClienteService();
        }

        /// <summary>
        /// Listagem de locações.
        /// </summary>
        /// <returns>200: Lista de locações. 400</returns>
        [HttpGet]
        public ActionResult<List<LocacaoDtoConsulta>> ObterTodos() =>
            Ok(ConverterDados(_locacaoService.ObterTodos()));

        /// <summary>
        /// Consulta de locação por ID.
        /// </summary>
        /// <param name="id">Id da locação.</param>
        /// <returns>200: Locação referente ao ID informado; 400</returns>
        [HttpGet("{id}")]
        public ActionResult<LocacaoDtoConsulta> ObterPorId(int id) =>
            Ok(_locacaoService.ObterPorId(id));

        /// <summary>
        /// Cadastro de locação.
        /// </summary>
        /// <param name="locacao">Dados da locação para cadastro.</param>
        /// <returns>200: Id da nova locação; 400: Mensagem de validação.</returns>
        [HttpPost]
        public ActionResult<RetornoInclusaoRegistroDto> Incluir([FromBody] LocacaoDto locacao) =>
            Ok(new RetornoInclusaoRegistroDto()
            {
                Id = _locacaoService.Incluir(
                new Locacao()
                {
                    Id_Cliente = locacao.Id_Cliente,
                    Id_Filme = locacao.Id_Filme,
                    DataDevolucao = locacao.DataDevolucao,
                    DataLocacao = locacao.DataLocacao
                })
            });

        /// <summary>
        /// Alteração no cadastro de locação.
        /// </summary>
        /// <param name="id">Id da locação a ser alterado.</param>
        /// <param name="locacao">Novos dados da locação.</param>
        /// <returns>200; 400: Mensagem de validação.</returns>
        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] LocacaoDto locacao)
        {
            _locacaoService.Alterar(id, new Locacao()
            {
                Id_Cliente = locacao.Id_Cliente,
                Id_Filme = locacao.Id_Filme,
                DataDevolucao = locacao.DataDevolucao,
                DataLocacao = locacao.DataLocacao
            });

            return Ok();
        }

        /// <summary>
        /// Exclui locações.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            _locacaoService.Excluir(id);
            return Ok();
        }

        private List<LocacaoDtoConsulta> ConverterDados(List<Locacao> locacoes)
        {
            var locacoesDto = new List<LocacaoDtoConsulta>();

            foreach (var item in locacoes)
            {
                var filme = _filmeService.ObterPorId(item.Id_Filme);
                var cliente = _clienteService.ObterPorId(item.Id_Cliente);

                locacoesDto.Add(new LocacaoDtoConsulta()
                {
                    Key = item.Id,
                    Id_Filme = item.Id_Filme,
                    Filme = filme.Titulo,
                    Id_Cliente = item.Id_Cliente,
                    Cliente = cliente.Nome,
                    DataLocacao = item.DataLocacao,
                    DataDevolucao = item.DataDevolucao,
                    DataPrevisaoDevolucao = filme.Lancamento ? item.DataLocacao?.AddDays(2) : item.DataLocacao?.AddDays(3)
                });
            }

            return locacoesDto;
        }
    }
}
