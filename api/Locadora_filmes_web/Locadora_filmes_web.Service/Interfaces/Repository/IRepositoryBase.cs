using System.Linq;

namespace Locadora_filmes_web.Service.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity, TKeyType> where TEntity : class
    {
        IQueryable<TEntity> ObterTodos();
        TEntity ObterPorId(TKeyType id);
        TKeyType Incluir(TEntity entity);
        void Alterar(TKeyType id, TEntity entity);
        void Exclusao(TKeyType id);
    }
}