using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora_filmes_web.Data.Entity
{
    public class Cliente : TabelaBase
    {
        /// <summary>
        /// Nome do cliente.
        /// </summary>
        [Column(TypeName = "Varchar(200)")]
        public string Nome { get; set; }

        /// <summary>
        /// Cpf do cliente.
        /// </summary>
        [Column(TypeName = "Varchar(11)")]
        public string Cpf { get; set; }

        /// <summary>
        /// Data de nascimento do cliente.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime DataNascimento { get; set; }
    }
}
