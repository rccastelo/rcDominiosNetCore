using Microsoft.EntityFrameworkCore;
using rcDominiosEntities;

namespace rcDominiosDatabase
{
    public class DominiosDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(Settings.GetDbConnectionString());
        }

        public DbSet<PessoaTipoEntity> PessoaTipo { get; set; }

        public DbSet<ProfissaoEntity> Profissao { get; set; }
    }
}
