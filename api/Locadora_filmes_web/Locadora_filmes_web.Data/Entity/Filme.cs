namespace Locadora_filmes_web.Data.Entity
{
    public class Filme : TabelaBase
    {
        public string Titulo { get; set; }
        public int ClassificacaoIndicada { get; set; }
        public bool Lancamento { get; set; }
    }
}