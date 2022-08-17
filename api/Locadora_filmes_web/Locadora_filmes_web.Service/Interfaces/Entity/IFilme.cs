namespace Locadora_filmes_web.Service.Interfaces.Entity
{
    public interface IFilme
    {
        /// <summary>
        /// Identificador do registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título do filme.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Classificação indicada do filme.
        /// </summary>
        public int ClassificacaoIndicada { get; set; }

        /// <summary>
        /// Flag para indicar se o filme é lançamento.
        /// </summary>
        public byte Lancamento { get; set; }
    }
}