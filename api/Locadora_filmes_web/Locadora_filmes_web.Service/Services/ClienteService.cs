using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Data.Repository;
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
            throw new System.NotImplementedException();
        }

        public void Exclusao(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Incluir(Cliente entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<Cliente> ObterTodos() => _clienteRepository.ObterTodos();

        public Cliente ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
