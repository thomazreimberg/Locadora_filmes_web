using System.ComponentModel.DataAnnotations;

namespace Locadora_filmes_web.Data.Entity
{
    public class TabelaBase
    {
        /// <summary>
        /// Id do registro.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
