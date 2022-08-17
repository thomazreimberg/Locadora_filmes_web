using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Data.Repository;
using System;
using System.Collections.Generic;

namespace Locadora_filmes_web.Service.Services
{
    public class ClienteService
    {
        public readonly ClienteRepository _clienteRepository;

        public ClienteService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public void Alterar(int id, Cliente entidade)
        {
            ValidarDados(entidade);

            _clienteRepository.Alterar(id, entidade);
        }

        public void Excluir(int id) =>
            _clienteRepository.Excluir(id);

        public int Incluir(Cliente entidade)
        {
            ValidarDados(entidade);

            return _clienteRepository.Incluir(entidade);
        }

        public List<Cliente> ObterTodos() => 
            _clienteRepository.ObterTodos();

        public Cliente ObterPorId(int id) =>
            _clienteRepository.ObterPorId(id);

        private void ValidarDados(Cliente entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.Nome))
                throw new ArgumentException("Nome do cliente não foi informado.");

            if (string.IsNullOrWhiteSpace(entidade.Cpf))
                throw new ArgumentException("Cpf do cliente não foi informado.");

            if (entidade.DataNascimento is null)
                throw new ArgumentException("Data de nascimento do cliente não foi informada.");
        }
    }
}
