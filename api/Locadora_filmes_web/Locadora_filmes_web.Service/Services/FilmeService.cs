using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_filmes_web.Service.Services
{
    public class FilmeService
    {
        public readonly FilmeRepository _filmeRepository;

        public FilmeService()
        {
            _filmeRepository = new FilmeRepository();
        }

        public void Alterar(int id, Filme entidade)
        {
            ValidarDados(entidade);
            _filmeRepository.Alterar(id, entidade);
        }

        public void Excluir(int id) =>
            _filmeRepository.Excluir(id);

        public int Incluir(Filme entidade)
        {
            ValidarDados(entidade);

            return _filmeRepository.Incluir(entidade);
        }

        public List<Filme> ObterTodos() =>
            _filmeRepository.ObterTodos().ToList();

        public Filme ObterPorId(int id) =>
            _filmeRepository.ObterPorId(id);

        private void ValidarDados(Filme entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.Titulo))
                throw new ArgumentException("Título do filme não foi informado.");

            if (entidade.ClassificacaoIndicada <= 0)
                throw new ArgumentException("Classificação indicada do filme não foi informada.");
        }
    }
}