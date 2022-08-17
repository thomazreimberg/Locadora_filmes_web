using Locadora_filmes_web.Data.Entity;
using System;
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
            var cliente = ObterPorId(id);
            cliente.Nome = entity.Nome;
            cliente.Cpf = entity.Cpf;
            cliente.DataNascimento = entity.DataNascimento;

            _dbContextClient.SaveChanges();
        }

        public void Excluir(int id)
        {
            var cliente = ObterPorId(id);

            _dbContextClient.Cliente.Remove(cliente);
            _dbContextClient.SaveChanges();
        }

        public int Incluir(Cliente entity)
        {
            _dbContextClient.Cliente.Add(entity);
            _dbContextClient.SaveChanges();

            return entity.Id;
        }

        public Cliente ObterPorId(int id)
        {
            var cliente = _dbContextClient.Cliente.FirstOrDefault(x => x.Id.Equals(id));

            if (cliente is null)
                throw new ArgumentException($"Cliente {id} não foi encontrado.");

            return cliente;
        }

        public List<Cliente> ObterTodos() =>
            _dbContextClient.Cliente.ToList();
    }
}
