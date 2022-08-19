using System;

namespace Locadora_filmes_web.Dtos.Locacao
{
    public class LocacaoDtoConsulta : LocacaoDto
    {
        public int Key { get; set; }
        public string Filme { get; set; }
        public string Cliente { get; set; }
        public DateTime? DataPrevisaoDevolucao { get; set; }
    }
}
