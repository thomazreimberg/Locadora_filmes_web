using System.Linq;

namespace Locadora_filmes_web.Service.Interfaces.Service
{
    public interface IServiceBase<TEntity, TKey, TFilters> where TEntity : class
    {
        TKey Incluir(TEntity entidade);
        void Alterar(TKey id, TEntity entidade);
        void Exclusao(TKey id);
        TEntity ObterPorId(TKey id);
        IQueryable<TEntity> ObterPorFiltros(TFilters filtros);
    }
}