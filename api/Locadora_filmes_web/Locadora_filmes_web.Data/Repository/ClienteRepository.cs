using Locadora_filmes_web.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_filmes_web.Data.Repository
{
    public class ClienteRepository
    {
        private readonly DbContextClient _dbContextClient;

        public ClienteRepository()
        {
            _dbContextClient = new DbContextClient();
        }

        public void Alterar(int id, Cliente entity)
        {
            throw new System.NotImplementedException();
        }

        public void Exclusao(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Incluir(Cliente entity)
        {
            throw new System.NotImplementedException();
        }

        public Cliente ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Cliente> ObterTodos() =>
            _dbContextClient.Cliente.ToList();
    }
}
