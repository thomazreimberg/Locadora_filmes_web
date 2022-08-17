using System;

namespace Locadora_filmes_web.Service.Interfaces.Entity
{
    public interface ILocacao
    {
        /// <summary>
        /// Identificador do registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id do cliente que alugou o filme.
        /// </summary>
        public int Id_Cliente { get; set; }

        /// <summary>
        /// Id do filme alugado pelo cliente.
        /// </summary>
        public int Id_Filme { get; set; }

        /// <summary>
        /// Data de retirada do filme pelo cliente.
        /// </summary>
        public DateTime DataLocacao { get; set; }

        /// <summary>
        /// Data de devolução do filme alugado.
        /// </summary>
        public DateTime DataDevolucao { get; set; }
    }
}
