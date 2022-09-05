using Locadora_filmes_web.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_filmes_web.Data.Repository
{
    public class FilmeRepository
    {
        private readonly DbContextClient _dbContextClient;

        public FilmeRepository()
        {
            _dbContextClient = new DbContextClient();
        }

        public void Alterar(int id, Filme entity)
        {
            var cliente = ObterPorId(id);
            cliente.Titulo = entity.Titulo;
            cliente.Lancamento = entity.Lancamento;
            cliente.ClassificacaoIndicada = entity.ClassificacaoIndicada;

            _dbContextClient.SaveChanges();
        }

        public void Excluir(int id)
        {
            var cliente = ObterPorId(id);

            _dbContextClient.Filme.Remove(cliente);
            _dbContextClient.SaveChanges();
        }

        public int Incluir(Filme entity)
        {
            _dbContextClient.Filme.Add(entity);
            _dbContextClient.SaveChanges();

            return entity.Id;
        }

        public Filme ObterPorId(int id)
        {
            var cliente = _dbContextClient.Filme.FirstOrDefault(x => x.Id.Equals(id));

            if (cliente is null)
                throw new ArgumentException($"Filme {id} não foi encontrado.");

            return cliente;
        }

        public IQueryable<Filme> ObterTodos() =>
            _dbContextClient.Filme;
    }
}
