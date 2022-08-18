using System;

namespace Locadora_filmes_web.Dtos.Locacao
{
    public class LocacaoDtoConsulta : LocacaoDto
    {
        public int Id { get; set; }
        public DateTime? DataPrevisaoDevolucao { get; set; }
    }
}
