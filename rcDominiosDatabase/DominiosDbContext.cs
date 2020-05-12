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

        public DbSet<CorEntity> Cor { get; set; }

        public DbSet<ContaBancariaEntity> ContaBancaria { get; set; }

        public DbSet<EnderecoTipoEntity> EnderecoTipo { get; set; }

        public DbSet<EstadoCivilEntity> EstadoCivil { get; set; }

        public DbSet<GeneroSocialEntity> GeneroSocial { get; set; }

        public DbSet<SexoEntity> Sexo { get; set; }
    }
}
