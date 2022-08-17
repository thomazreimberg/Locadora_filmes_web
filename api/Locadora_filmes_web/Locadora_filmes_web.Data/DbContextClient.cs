using Locadora_filmes_web.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Locadora_filmes_web.Data
{
    public class DbContextClient : DbContext
    {
        #region Propriedades privadas
        private string _stringConexaoBd { get; set; }
        #endregion

        public DbContextClient()
        {
            // Estrutura feita dessa forma para fins demonstrativos.
            _stringConexaoBd = "server=127.0.0.1;port=3366;database=Locadora_filmes_web;uid=root;password=spypreto";
        }

        #region Tabelas
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_stringConexaoBd);
        }
    }
}
