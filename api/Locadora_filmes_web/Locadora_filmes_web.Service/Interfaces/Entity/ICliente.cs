using System;

namespace Locadora_filmes_web.Service.Interfaces.Entity
{
    public interface ICliente
    {
        /// <summary>
        /// Identificador do registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Cpf do cliente.
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Data de nascimento do cliente.
        /// </summary>
        public DateTime DataNascimento { get; set; }
    }
}