using AUBNB.Domain.Features.Hostings;
using AUBNB.Domain.Features.Users;
using AUBNB.Infra.Data.Features.Hostings;
using AUBNB.Infra.Data.Features.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AUBNB.Infra.Data.Contexts
{
    public class AUBNBDbContext : DbContext
    {
        public AUBNBDbContext(DbContextOptions<AUBNBDbContext> options) : base(options)
        {
            TryApplyMigration(options);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hosting> Hostings { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">É o construtor de modelos do EF</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HostingEntityConfiguration());
            modelBuilder.HasDefaultSchema("dbo");

            // Chama o OnModelCreating do EF para dar continuidade na criação do modelo
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies(false);

        private void TryApplyMigration(DbContextOptions<AUBNBDbContext> options)
        {
            var inMemoryConfiguration = options.Extensions.FirstOrDefault(x => x.ToString().Contains("InMemoryOptionsExtension"));

            if (inMemoryConfiguration == null && Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }
    }
}
