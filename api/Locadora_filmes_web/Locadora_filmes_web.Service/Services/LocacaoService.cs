using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Data.Repository;
using System;
using System.Collections.Generic;

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
            _locacaoRepository.ObterTodos();

        public Locacao ObterPorId(int id) =>
            _locacaoRepository.ObterPorId(id);

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