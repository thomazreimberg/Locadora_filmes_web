using System;

namespace Locadora_filmes_web.Dtos.Cliente
{
    public class ClienteDto
    {
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
