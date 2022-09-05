using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Data.Repository;
using Locadora_filmes_web.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_filmes_web.Service.Services
{
    public class LocacaoService
    {
        public readonly LocacaoRepository _locacaoRepository;
        public readonly FilmeRepository _filmeRepository;
        public readonly ClienteRepository _clienteRepository;

        public LocacaoService()
        {
            _locacaoRepository = new LocacaoRepository();
            _filmeRepository = new FilmeRepository();
            _clienteRepository = new ClienteRepository();
        }

        public void Alterar(int id, Locacao entidade)
        {
            ValidarDados(entidade);

            _locacaoRepository.Alterar(id, entidade);
        }

        public void Excluir(int id) =>
            _locacaoRepository.Excluir(id);

        public int Incluir(Locacao entidade)
        {
            ValidarDados(entidade);
            entidade.DataDevolucao = null;
            if (entidade.DataLocacao is null)
                entidade.DataLocacao = DateTime.Now.Date;

            return _locacaoRepository.Incluir(entidade);
        }

        public List<Locacao> ObterTodos() =>
            _locacaoRepository.ObterTodos().ToList();

        public Locacao ObterPorId(int id) =>
            _locacaoRepository.ObterPorId(id);

        public Cliente ObterClienteComprador()
        {
            var locacoes = _locacaoRepository.ObterTodos()
                .GroupBy(x => x.Id_Cliente)
                .Select(x => new ClienteLocacoes()
                {
                    IdCliente = x.Key,
                    Quantidade = x.Count()
                })
                .ToList();

            return locacoes.Count() > 1 ? _clienteRepository.ObterPorId(locacoes[1].IdCliente) : _clienteRepository.ObterPorId(locacoes[0].IdCliente);
        }

        public List<Cliente> ObterClientesAtrasoDevolucao() =>
            _locacaoRepository.ObterTodos()
                .Include(x => x.Cliente)
                .Where(x => x.DataDevolucao == null && x.DataLocacao.Value.Date < (DateTime.Now.Date.AddDays(-3)))
                .Select(x => new Cliente()
                {
                    Id = x.Id_Cliente,
                    Nome = x.Cliente.Nome,
                    Cpf = x.Cliente.Cpf,
                    DataNascimento = x.Cliente.DataNascimento
                })
                .ToList();

        public List<Filme> ObterFilmesNaoAlugados()
        {
            var filmesAlugados = _locacaoRepository.ObterTodos()
                .GroupBy(x => x.Id_Filme)
                .Select(x => x.Key)
                .ToList();

            return _filmeRepository.ObterTodos()
                .Where(x => !filmesAlugados.Contains(x.Id))
                .ToList();
        }
            

        private void ValidarDados(Locacao entidade)
        {
            var cliente = _clienteRepository.ObterPorId(entidade.Id_Cliente);
            var filme = _filmeRepository.ObterPorId(entidade.Id_Filme);

            if (CalcularIdade(cliente.DataNascimento) < filme.ClassificacaoIndicada)
                throw new ArgumentException("Cliente não tem a idade indicada para o aluguel do filme.");
        }

        private int CalcularIdade(DateTime data)
        {
            var today = DateTime.Now.Date;
            var age = today.Year - data.Year;
            if (data > today.AddYears(-age)) age--;

            return age;
        }
    }
}