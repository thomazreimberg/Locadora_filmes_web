using Locadora_filmes_web.Data.Entity;
using System;
using System.Linq;

namespace Locadora_filmes_web.Data.Repository
{
    public class LocacaoRepository
    {
        private readonly DbContextClient _dbContextClient;

        public LocacaoRepository()
        {
            _dbContextClient = new DbContextClient();
        }

        public void Alterar(int id, Locacao entity)
        {
            var cliente = ObterPorId(id);
            cliente.Id_Cliente = entity.Id_Cliente;
            cliente.Id_Filme = entity.Id_Filme;
            cliente.DataDevolucao = entity.DataDevolucao;

            _dbContextClient.SaveChanges();
        }

        public void Excluir(int id)
        {
            var cliente = ObterPorId(id);

            _dbContextClient.Locacao.Remove(cliente);
            _dbContextClient.SaveChanges();
        }

        public int Incluir(Locacao entity)
        {
            _dbContextClient.Locacao.Add(entity);
            _dbContextClient.SaveChanges();

            return entity.Id;
        }

        public Locacao ObterPorId(int id)
        {
            var locacao = _dbContextClient.Locacao.FirstOrDefault(x => x.Id.Equals(id));

            if (locacao is null)
                throw new ArgumentException($"Locação {id} não foi encontrada.");

            return locacao;
        }

        public IQueryable<Locacao> ObterTodos() =>
            _dbContextClient.Locacao;
    }
}