using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Dtos;
using Locadora_filmes_web.Dtos.Filme;
using Locadora_filmes_web.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Locadora_filmes_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : Controller
    {
        private FilmeService _filmeService { get; set; }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public FilmeController()
        {
            _filmeService = new FilmeService();
        }

        /// <summary>
        /// Listagem de filmes.
        /// </summary>
        /// <returns>200: Lista de filmes. 400</returns>
        [HttpGet]
        public ActionResult<List<FilmeDtoConsulta>> ObterTodos() =>
            Ok(_filmeService.ObterTodos());

        /// <summary>-
        /// Consulta de filme por ID.
        /// </summary>
        /// <param name="id">Id do filme.</param>
        /// <returns>200: Filme referente ao ID informado; 400</returns>
        [HttpGet("{id}")]
        public ActionResult<FilmeDtoConsulta> ObterPorId(int id) =>
            Ok(_filmeService.ObterPorId(id));

        /// <summary>
        /// Cadastro de filme.
        /// </summary>
        /// <param name="filme">Dados do filme para cadastro.</param>
        /// <returns>200: Id do novo filme; 400: Mensagem de validação.</returns>
        [HttpPost]
        public ActionResult<RetornoInclusaoRegistroDto> Incluir([FromBody] FilmeDto filme) =>
            Ok(new RetornoInclusaoRegistroDto() { Id = _filmeService.Incluir(
                new Filme()
                {
                    Titulo = filme.Titulo,
                    Lancamento = filme.Lancamento,
                    ClassificacaoIndicada = filme.ClassificacaoIndicada
                })
            });

        /// <summary>
        /// Alteração no cadastro de filme.
        /// </summary>
        /// <param name="id">Id do filme a ser alterado.</param>
        /// <param name="filme">Novos dados do filme.</param>
        /// <returns>200; 400: Mensagem de validação.</returns>
        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] FilmeDto filme)
        {
            _filmeService.Alterar(id, new Filme()
            {
                Titulo = filme.Titulo,
                Lancamento = filme.Lancamento,
                ClassificacaoIndicada = filme.ClassificacaoIndicada
            });

            return Ok();
        }

        /// <summary>
        /// Exclui filmes.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            _filmeService.Excluir(id);
            return Ok();
        }
    }
}
