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
            _stringConexaoBd = "server=localhost;database=Locadora_filmes_web;uid=root;password=spypreto";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_stringConexaoBd);
        }
    }
}
