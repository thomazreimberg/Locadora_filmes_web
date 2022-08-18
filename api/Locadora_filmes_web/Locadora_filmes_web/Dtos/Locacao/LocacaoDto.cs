using System;

namespace Locadora_filmes_web.Dtos.Locacao
{
    public class LocacaoDto
    {
        public int Id_Cliente { get; set; }
        public int Id_Filme { get; set; }
        public DateTime? DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
